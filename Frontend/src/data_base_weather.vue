<script>
import axios from 'axios'

export default {
  data() {
    return {
      weatherData: [],
    }
  },
  methods: {
    async fetchApi() {
      try {
        const response = await axios.get('http://localhost:5145/api')
        this.weatherData = response.data
      } catch (err) {
        console.log('Failed to fetch data', err)
      }
    },
  },
  mounted() {
    this.fetchApi()
  },
}
</script>

<template>
  <div>
    <h2>API Data</h2>
    <table v-if="weatherData.length">
      <thead>
        <tr>
          <th v-for="(value, key) in weatherData[0]" :key="key">{{ key }}</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="item in weatherData" :key="item.id">
          <td v-for="(value, key) in item" :key="key">{{ value }}</td>
        </tr>
      </tbody>
    </table>
    <p v-else>No data available.</p>
  </div>
</template>

<style>
table {
  width: 100%;
  border-collapse: collapse;
  margin-top: 10px;
}
th,
td {
  border: 1px solid #ddd;
  padding: 8px;
}
th {
  background-color: #f4f4f4;
  text-align: left;
}
</style>

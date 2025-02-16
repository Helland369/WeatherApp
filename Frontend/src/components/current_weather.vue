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
        const response = await axios.get('http://localhost:5285/api/weather/live')
        console.log('Response data', response.data)
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
    <table v-if="Object.keys(weatherData).length" class="w-full border-collaps mt-2">
      <thead>
        <tr>
          <th
            v-for="(value, key) in weatherData[0]"
            :key="key"
            class="border border-gray-300 bg-gray-900 text-left p-2"
          >
            {{ key }}
          </th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td v-for="(value, key) in weatherData" :key="key" class="border border-gray-300 p-2">
            {{ value }}
          </td>
        </tr>
      </tbody>
    </table>
    <p v-else>No data available</p>
  </div>
</template>

<style></style>

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
  <div v-if="weatherData">
    <h2>Current weather for your location</h2>

    <p><strong>Location:</strong> {{ weatherData.name }}</p>
    <!-- <p><strong>Temperature:</strong> {{ weatherData.main.temp }}</p> -->
    <!-- <p><strong>Minimum Temperature:</strong> {{ weatherData.main.temp_min }}</p> -->
    <!-- <p><strong>Maximum Temperature:</strong> {{ weatherData.main.temp_max }}</p> -->
    <!-- <p><strong>Feels like:</strong> {{ weatherData.main.feels_like }}</p> -->
    <!-- <p><strong>Humidity:</strong> {{ weatherData.main.humidity }}</p> -->
    <!-- <p><strong>Pressure:</strong> {{ weatherData.main.pressure }}</p> -->
    <!-- <p><strong>Sea level:</strong> {{ weatherData.main.sea_level }}</p> -->
    <!-- <p><strong>Ground level:</strong> {{ weatherData.main.grnd_level }}</p> -->
  </div>
</template>

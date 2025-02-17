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

<!-- {"coord":{"lon":11.1629,"lat":59.5833},"weather":[{"id":803,"main":"Clouds","description":"broken clouds","icon":"04d"}], -->
<!-- "base":"stations","main":{"temp":1.32,"feels_like":0,"temp_min":0.48,"temp_max":1.32,"pressure":1023,"humidity":55, -->
<!-- "sea_level":1023,"grnd_level":1004},"visibility":10000,"wind":{"speed":1.34,"deg":319,"gust":2.24},"clouds":{"all":65}, -->
<!-- "dt":1739795418,"sys":{"type":2,"id":2003947,"country":"NO","sunrise":1739774803,"sunset":1739808736},"timezone":3600,"id":3162651,"name":"Askim","cod":200} -->

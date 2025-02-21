<script>
import axios from 'axios'

export default {
  data() {
    return {
      weatherData: null,
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
    <h2 class="flex justify-center items-center">Current weather for your location</h2>

    <div class="flex justify-center items-center">
      <strong>Location:</strong> {{ weatherData.name }}
      <svg
        class="h-8 w-8 text-red-500"
        viewBox="0 0 24 24"
        fill="none"
        stroke="currentColor"
        stroke-width="2"
        stroke-linecap="round"
        stroke-linejoin="round"
      >
        <circle cx="12" cy="12" r="10" />
        <circle cx="12" cy="12" r="6" />
        <circle cx="12" cy="12" r="2" />
      </svg>
    </div>
    <div class="flex justify-center items-center">
      <strong>Temperature:</strong> {{ weatherData.main?.temp }}
      <svg
        class="h-5 w-5 text-white-500"
        width="24"
        height="24"
        viewBox="0 0 24 24"
        stroke-width="2"
        stroke="currentColor"
        fill="none"
        stroke-linecap="round"
        stroke-linejoin="round"
      >
        <path stroke="none" d="M0 0h24v24H0z" />
        <circle cx="6" cy="8" r="2" />
        <path d="M20 9a3 3 0 0 0 -3 -3h-1a3 3 0 0 0 -3 3v6a3 3 0 0 0 3 3h1a3 3 0 0 0 3 -3" />
      </svg>
    </div>
    <div class="flex justify-center items-center">
      <strong>Minimum Temperature:</strong> {{ weatherData.main?.temp_min }}
      <svg
        class="h-5 w-5 text-white-500"
        width="24"
        height="24"
        viewBox="0 0 24 24"
        stroke-width="2"
        stroke="currentColor"
        fill="none"
        stroke-linecap="round"
        stroke-linejoin="round"
      >
        <path stroke="none" d="M0 0h24v24H0z" />
        <circle cx="6" cy="8" r="2" />
        <path d="M20 9a3 3 0 0 0 -3 -3h-1a3 3 0 0 0 -3 3v6a3 3 0 0 0 3 3h1a3 3 0 0 0 3 -3" />
      </svg>
    </div>
    <div class="flex justify-center items-center">
      <strong>Maximum Temperature:</strong> {{ weatherData.main?.temp_max }}
      <svg
        class="h-5 w-5 text-white-500"
        width="24"
        height="24"
        viewBox="0 0 24 24"
        stroke-width="2"
        stroke="currentColor"
        fill="none"
        stroke-linecap="round"
        stroke-linejoin="round"
      >
        <path stroke="none" d="M0 0h24v24H0z" />
        <circle cx="6" cy="8" r="2" />
        <path d="M20 9a3 3 0 0 0 -3 -3h-1a3 3 0 0 0 -3 3v6a3 3 0 0 0 3 3h1a3 3 0 0 0 3 -3" />
      </svg>
    </div>
    <div class="flex justify-center items-center">
      <strong>Feels like:</strong> {{ weatherData.main?.feels_like }}
      <svg
        class="h-5 w-5 text-white-500"
        width="24"
        height="24"
        viewBox="0 0 24 24"
        stroke-width="2"
        stroke="currentColor"
        fill="none"
        stroke-linecap="round"
        stroke-linejoin="round"
      >
        <path stroke="none" d="M0 0h24v24H0z" />
        <circle cx="6" cy="8" r="2" />
        <path d="M20 9a3 3 0 0 0 -3 -3h-1a3 3 0 0 0 -3 3v6a3 3 0 0 0 3 3h1a3 3 0 0 0 3 -3" />
      </svg>
    </div>
    <div class="flex justify-center items-center">
      <strong>Humidity:</strong> {{ weatherData.main?.humidity }} %
    </div>
    <div class="flex justify-center items-center">
      <strong>Pressure:</strong> {{ weatherData.main?.pressure }} hPa
    </div>
    <div class="flex justify-center items-center">
      <strong>Sea level:</strong> {{ weatherData.main?.sea_level }} m
    </div>
    <div class="flex justify-center items-center">
      <strong>Ground level:</strong> {{ weatherData.main?.grnd_level }} m
    </div>
  </div>
</template>

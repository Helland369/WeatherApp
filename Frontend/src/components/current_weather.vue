<script setup>
import weather_map from './weather_map.vue'
import { ref, onMounted } from 'vue'
import axios from 'axios'

const weatherData = ref(null)

const fetchApi = async () => {
  try {
    const response = await axios.get('http://localhost:5285/api/weather/live')
    console.log('Response data', response.data)
    weatherData.value = response.data
  } catch (err) {
    console.log('Failed to fetch data', err)
  }
}

onMounted(fetchApi)
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
      <strong>Temperature:</strong> {{ weatherData.main?.temp }} °C
    </div>
    <div class="flex justify-center items-center">
      <strong>Minimum Temperature:</strong> {{ weatherData.main?.temp_min }} °C
    </div>
    <div class="flex justify-center items-center">
      <strong>Maximum Temperature:</strong> {{ weatherData.main?.temp_max }} °C
    </div>
    <div class="flex justify-center items-center">
      <strong>Feels like:</strong> {{ weatherData.main?.feels_like }} °C
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

  <weather_map />
</template>

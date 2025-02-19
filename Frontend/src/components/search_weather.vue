<script setup>
import { ref, onMounted, watch } from 'vue'
import { useRoute } from 'vue-router'
import axios from 'axios'

const route = useRoute()
const city = ref(route.params.city)
const weatherData = ref(null)

const fetchWeather = async () => {
  if (!city.value) return
  try {
    const response = await axios.get(`http://localhost:5285/api/weather/search`, {
      params: { city: city.value },
    })
    weatherData.value = response.data
  } catch (err) {
    console.error('Error while fetching weather data', err)
  }
}

onMounted(fetchWeather)

// fixes the refresh thing
watch(
  () => route.params.city,
  (newCity) => {
    city.value = newCity
    fetchWeather()
  },
)
</script>

<template>
  <div v-if="weatherData">
    <h2 class="text-center text-2xl font-bold">Weather for {{ weatherData.name }}</h2>
    <div class="flex flex-col items-center space-y-4 mt-4">
      <p><strong>Temperature:</strong> {{ weatherData.main?.temp }} °C</p>
      <p><strong>Feels Like:</strong> {{ weatherData.main?.feels_like }} °C</p>
      <p><strong>Humidity:</strong> {{ weatherData.main?.humidity }}%</p>
      <p><strong>Pressure:</strong> {{ weatherData.main?.pressure }} hPa</p>
    </div>
  </div>
  <p v-else class="text-center mt-4">Loading weather data...</p>
</template>

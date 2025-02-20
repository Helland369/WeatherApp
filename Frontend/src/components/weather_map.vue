<script setup>
import { onMounted } from 'vue'
import L from 'leaflet'
import 'leaflet/dist/leaflet.css'

onMounted(() => {
  const map = L.map('map').setView([60.0, 10.0], 6)

  L.tileLayer(
    'https://tile.thunderforest.com/outdoors/{z}/{x}/{y}.png?apikey=//APIKEY',
    {
      attribution: '&copy; Thunderforest, OpenStreetMap contributors',
    },
  ).addTo(map)

  map.on('click', async (e) => {
    const lat = e.latlng.lat
    const lon = e.latlng.lng
    fetchWeather(lat, lon)
  })
})

async function fetchWeather(lat, lon) {
  try {
    const response = await fetch(`http://localhost:5285/api/weather/map?lat=${lat}&lon=${lon}`)
    const data = await response.json()
    alert(`Weather at (${lat}, ${lon}): ${data.weather[0].description}`)
  } catch (error) {
    console.error('Error fetching weather data', error)
  }
}
</script>

<template>
  <div id="map"></div>
</template>

<style scoped>
#map {
  height: 500px;
  width: 100%;
}
</style>

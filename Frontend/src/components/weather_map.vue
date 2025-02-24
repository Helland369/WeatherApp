<script setup>
import { GoogleMap, Marker } from 'vue3-google-map'
import { ref } from 'vue'
import axios from 'axios'

const center = { lat: 62.0, lng: 10.0 }

const marker = ref(null)
const weather = ref(null)

const onMapClick = async (event) => {
  const lat = event.latLng.lat()
  const lng = event.latLng.lng()
  marker.value = { lat, lng } // Place a marker at the clicked location

  console.log(`Fetching weather for: ${lat}, ${lng}`)

  try {
    const response = await axios.get(`http://localhost:5285/api/weather/map`, {
      params: { lon: lng, lat: lat },
    })
    console.log('Weather API response:', response.data)
    weather.value = response.data
  } catch (error) {
    console.error('Error fetching weather data:', error)
  }
  return { marker, weather, onMapClick }
}
</script>

<template>
  <GoogleMap
    api-key="//APIKEY"
    mapId="WEATHER_MAP"
    style="width: 100%; height: 500px"
    :center="center"
    :zoom="6"
    @click="onMapClick"
  >
    <Marker v-if="marker" :options="{ position: marker }" />
    <!-- <Marker :options="{ position: center }" /> -->
  </GoogleMap>

  <div v-if="weather">
    <h2>Weather at ({{ weather.coord.lat }}, {{ weather.coord.lon }})</h2>
    <h2>Place: {{ weather.name }}</h2>
    <p>Temperature: {{ weather.main.temp }}°C</p>
    <p>Feels Like: {{ weather.main.feels_like }}°C</p>
    <p>Humidity: {{ weather.main.humidity }}%</p>
    <p>Pressure: {{ weather.main.pressure }} hPa</p>
  </div>
</template>

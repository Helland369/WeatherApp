import { createRouter, createWebHistory } from 'vue-router'
import homeView from '@/views/home_view.vue'
import data_base_view from '@/views/data_base_view.vue'
import search_weather from '@/views/search_weather.vue'
import weather_map from '@/views/weather_map.vue'
//import { defaults } from 'autoprefixer'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: homeView,
    },
    {
      path: '/data_base',
      name: 'data_base',
      component: data_base_view,
    },
    {
      path: '/weather/:city',
      name: 'search',
      component: search_weather,
    },
    {
      path: '/weather/map',
      name: 'map',
      component: weather_map,
    },
  ],
})

export default router

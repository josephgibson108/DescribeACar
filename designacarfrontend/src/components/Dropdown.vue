<template>
<div>
    <!-- <select v-on:change="$store.commit("SET_ACTIVE_CAR", selectedCar)" v-model="selectedCar">
      <option v-for="car in $store.state.cars" v-bind:key="car.id">{{car.year}} {{car.make}} {{car.model}}</option>
    </select>
    this img isn't properly utilized
    <img src=$store.state.activeCar.url/> -->
</div>
</template>

<script>
import CarService from '../services/CarService.js'

export default {
    name: '',
    props: [],
    methods: '',
    created() {
        CarService.getCars().then((response) => {
            this.$store.commit("GET_CARS", response.data);
        })
        .catch(error => {
                alert("Error obtaining list of all Cars:" + error);
            }
        );
    }
}
</script>

<style>

</style>
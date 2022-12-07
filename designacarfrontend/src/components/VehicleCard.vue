<template>
  <div id="root">
    <div class="card">
      <div class="card-text">
        <h2 class="make">Make: {{car.Make}}</h2>
        <h2 class="model">Model: {{car.Model}}</h2>
        <h2 class="year">Year: {{car.Year}}</h2>
        <button class="del-btn" v-on:click="deleteThisCar">Delete Car</button>
      </div>
      <div class="img-div">
        <img class="car-img" alt="User-provided image of vehicle" :src="car.URL"/>
      </div>
    </div>
  </div>
</template>

<script>
import CarService from '../services/CarService.js';

export default {
  
  name: 'VehicleCard',
  props: ['car'],
  data() {
    return {
      errorMsg: ''
    }
  },
  methods: {
    deleteThisCar() {
      if(confirm("Are you sure you want to delete this car?")){
        CarService.deleteCar(this.car.CarId).then(() => {
          alert("Car deleted.");
          this.$router.go(); // refreshes page
        }).catch((error) => {
          if (error.response) {
            this.errorMsg = "Error deleting the car; response: " + error.response.statusText + ".";
          }
          else if (error.request) {
            this.errorMsg = "Error deleting the car; could not reach the server.";
          }
          else {
            this.errorMsg = "Error deleting the car; could not make request.";
          }
        })
      }
    }
  }
}

</script>

<style>
  #root{
    display: grid;
  }
  .card {
    border-color: cornflowerblue;
    border-width: 5px;
    gap: 10px;
    border-style: solid;
    display: grid;
    grid-template-columns: 1fr 1fr;
    grid-template-areas: 
    "card-text img"
    ;
    border-radius: 10px;
    
  }

  .card:hover {
    background-color: rgb(227, 233, 243);
  }

  .card-text{
    grid-area: card-text;
    position: relative;
    align-self: center;
  }

  .del-btn {
    grid-area: del;
    width: 100px;
    background-color: red;
    color: white;
    align-content: center;
    margin-bottom: 16px;
  }

  .del-btn:hover {
    background-color: rgb(200, 0, 0);
    cursor: pointer;
  }

  .img-div {
    grid-area: img;
    height: 200px;
    width: 350px;
    padding: 10px;
    border-style: solid;
    border-width: 2px;
    border-color: orange;
    margin: 10px;
    position: relative;
  }

  .car-img {
    max-height: 200px;
    max-width: 350px;
    /* absolute allow us to define position outside of everything else
       Defined inside of relative, so it's relative to the parent img-div */
    position: absolute;
    /* top left corner is centered */
    top: 50%;
    left: 50%;
    /* half own width over, half own height down */
    transform: translate(-50%, -50%);
  }

  .make {
    grid-area: make;
  }
  .model {
    grid-area: model;
  }
  .year {
    grid-area: year;
  }
</style>
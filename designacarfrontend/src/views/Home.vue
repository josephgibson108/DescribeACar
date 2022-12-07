<template>
  <div class="home">
    <section id="head">
      <h1 id="title">DESCRIBE A CAR</h1>
      <section class="btn-section">
        <button class="form-btn" v-on:click="showForm = true" v-if="showForm === false">Add a Car</button>
      </section>
      <h4 id="copyright">Joe Gibson 2022</h4>
    </section>
    <form class="form-container" v-on:submit.prevent="createCar" v-show="showForm === true">
      <div class="form-element">
        <label for="make" class="label">Make:</label>
        <input id="make" class="input" type="text" v-model="newCar.Make" />
      </div>
      <div class="form-element">
        <label for="model" class="label">Model:</label>
        <input id="model" class="input" type="text" v-model="newCar.Model" />
      </div>
      <div class="form-element">
        <label for="year" class="label">Year:</label>
        <input id="year" class="input" type="int" v-model="newCar.Year" />
      </div>
      <div class="form-element">
        <label for="url" class="label">Image URL:</label>
        <input id="url" class="input" type="text" v-model="newCar.URL" />
      </div>
      <input type="submit" value="Save" class="btn">
      <input type="button" class="btn" value="Cancel" v-on:click="resetForm">
    </form>
    <vehicle-card class="vehicle-card" v-for="(value, key) in $store.state.cars" v-bind:key="key" :car="value"/>
  </div>
</template>

<script>
import CarService from '../services/CarService.js';
import VehicleCard from '../components/VehicleCard.vue';

export default {
  name: 'Home',
  props: ['car'],
  data(){
    return {
      newCar: {},
      showForm: false
    }
  },
  methods: {
    createCar(){
      CarService.createCar(this.newCar).then(() => {
        alert("Nice car!");
        this.$router.go();
      })
      .catch(() => {
        console.log(this.$store.state.cars);
        alert ("Invalid input; please try again.");
      })
    },
    resetForm() {
      this.newCar = {};
      this.showForm = false;
    }
  },
  components: {
    VehicleCard
  },
    created() {
        CarService.getCars().then((response) => {
            this.$store.commit("GET_CARS", response.data);
        })
        .catch(error => {
                alert("Error obtaining list of all Cars: " + error);
            }
        );
    }
}
</script>

<style>
#head {
  background-color: cornflowerblue;
  display: grid;
  grid-template-columns: 300px 1fr 200px;
  grid-template-areas: 
  "title form-btn copyright"
  ;
}

#title {
  grid-area: title;
  color: black;
}

.vehicle-card{
  padding-top: 5px;
}

/* the add car button */
.form-btn{
  grid-area: form-btn;
  width: 100px;
  height: 40px;
  display: grid;
  justify-content: left;
  align-content: center;
  background-color: orange;
  font-weight: bold;
  font-size: 17px
}

.form-btn:hover {
  background-color: rgb(255, 218, 149);
  cursor: pointer;
}

.form-container {
  background-color: rgb(255, 218, 149);
  display: block;
  width: 300px;
  /* first param specifies top and bottom, second is left and right */
  margin: 5px auto;
  margin-bottom: 0;
}

.form-element {
  padding: 5px;
}

.label {
  font-weight: bold;
  display: inline-block;
  width: 39%;
  text-align: right;
  margin-right: 10px;
}

.input {
  display: inline-block;
  width: 49%;
  margin-left: 10px;
}

.btn:hover {
  cursor: pointer;
  background-color: whitesmoke;
}

.btn {
  margin: 2px 10px 5px 10px;
  font-family: 'Trebuchet MS';
  background-color: rgb(198, 214, 245);
  border-radius: 5px;
}

/* the area that holds the button */
.btn-section{
  display: flex;
  align-items: center;
}
#copyright {
  grid-area: copyright;
  align-items: center;
  justify-content: center;
}

</style>

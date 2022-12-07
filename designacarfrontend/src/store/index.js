import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    cars: [],
    car: {
      id: 0,
      make: '',
      model: '',
      year: ''
    }
  },
  mutations: {
    GET_CARS(state, data) {
      state.cars = data;
    },
    SET_ACTIVE_CAR(state, data) {
      state.activeCar = data;
    },
    DELETE_CAR(state, carIdToDelete) {
      state.cars = state.cars.filter((car) => {
        return car.id !== carIdToDelete;
      });
    }
  },
  actions: {
  },
  modules: {
  }
})

import axios from "axios";

const http = axios.create({
    baseURL: "http://localhost:16078/car"
  });

export default {
    getCar(id) {
        return http.get(`/${id}`);
    },

    getCars() {
        // empty string OR nothing, not sure yet
        return http.get();
    },

    updateCar(id, car) {
        return http.put(`/${id}`, car);
    },

    deleteCar(id) {
        return http.delete(`/${id}`);
    },

    createCar(car) {
        // empty string OR nothing, not sure yet
        return http.post("/", car)
    }
};
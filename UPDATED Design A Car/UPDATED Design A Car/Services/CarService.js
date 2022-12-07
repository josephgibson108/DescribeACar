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
        return http.post()
    }
};



// getBoards() {
//     return http.get('/boards');
//   },

//   getCards(boardID) {
//     return http.get(`/boards/${boardID}`)
//   },

//   getCard(boardID, cardID) {
//     return http.get(`/boards/${boardID}`).then((response) => {
//       const cards = response.data.cards;
//       return cards.find(card => card.id == cardID);
//     })
//   }
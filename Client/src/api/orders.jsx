import axios from 'axios';

const BASE_URL = "https://127.0.0.1:5000/api/orders"

export const getOrderById = (id) => {
  return axios.get(`${BASE_URL}/${id}`);
}

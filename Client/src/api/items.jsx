import axios from 'axios';

const BASE_URL = "https://127.0.0.1:5000/api/items";


export const getAllItems = (pageSize, pageNumber) => {
  return axios.get(BASE_URL, {
    params: { pageNumber, pageSize }
  })
}

export const getItemById = (id) => {
  return axios.get(`${BASE_URL}/${id}`)
}

export const getItemReviews = (itemId, pageSize, pageNumber) => {
  return axios.get(`${BASE_URL}/${itemId}/reviews`, {
    params: { pageNumber, pageSize }
  })
}

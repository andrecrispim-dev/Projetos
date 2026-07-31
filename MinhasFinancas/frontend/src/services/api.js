import axios from 'axios';

const api = axios.create({
    // Aponta para o backend local porta 3000
    baseURL: 'http://localhost:3000/api',
    timeout: 10000, 
    headers: {
        'Content-Type': 'application/json'
    }
});

export default api;

import axios from 'axios';
import Cookies from 'js-cookie';
import type { ApiRequestParams } from '../../interfaces/IApiRequestParams';

export const apiRequest = async ({ url, method = 'GET', data = {}, params = null }: ApiRequestParams) => {
  try {
    const token = Cookies.get('apiAccessToken');
    if (!token ) {
      throw new Error('Authorization tokenfound in session.');
    }   
    const response = await axios({
      url,
      method,
      baseURL: import.meta.env.VITE_API_BASE_URL,
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${token}`,
      },
      data,   
      params,
    });

    return response.data;
  } catch (error) {
    console.error('API Request Failed:', error);
    throw error;
  }
};

export const apiRequestAnonymous = async ({ url, method = 'POST', data = {}, params = null }: ApiRequestParams) => {

  try {
    const response: any = await axios({
      url,
      method,
      baseURL: import.meta.env.VITE_API_BASE_URL,
      headers: {
        'Content-Type': 'application/json',
      },
      data,
      params,
    });
    return response.data;
  } catch (error) {
    console.error('API Request Failed:', error);
    throw error;
  }
}
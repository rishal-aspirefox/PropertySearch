import { apiRequest, apiRequestAnonymous } from "../connections/ClientApis";

export  const logInUser = (credentials: { email: string; password: string }) =>{
 return apiRequestAnonymous({
    url: `/Auth/Login`,
    method: "POST",
    data: credentials,
  });
}

export const getProperties = async (filter?: any) => {
  return await apiRequest({
    url: `/Properties/GetProperties`,
    method: "GET",
    params: filter || {}
  });
};


export const getPropertyById = async (id: string|undefined) => {
  return await apiRequest({
    url: `/Properties/GetProperty/${id}`,
    method: "GET"
  });
}

export const addProperty = async (propertyData: any) => {

  return await apiRequest({
    url: `Properties/CreateProperty`,
    method: "POST",
    data: propertyData
  });
}

export const getSpaces = async() =>{
  return await apiRequest({
    url: `Spaces/GetSpaces`,
    method: "GET"
  });
}


export const getCountries = async() =>{
  return await apiRequest({
    url: `Common/GetAllCountries`,
    method: "GET"
  });
}

export const getStates = async (countryId: string) => {
  return await apiRequest({
    url: `Common/GetAllStates?countryId=${countryId}`,
    method: "GET",
  });
};  


export const fetchAverageSpaceSize = async(id: string | undefined) =>{
  return await apiRequest({
    url: `Spaces/GetAverageSpaceSize`,
    method: "GET",
    params: { propertyId: id }
  });
}
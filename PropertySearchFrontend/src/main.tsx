import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.tsx'
import {createBrowserRouter, RouterProvider } from 'react-router-dom'
import ProtectedRoute from './components/ProtectedRoute.tsx'
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap-icons/font/bootstrap-icons.css";
import AuthProvider from './components/AuthProvider.tsx'
import Login from './components/Login.tsx'
import PropertyDetails from './pages/PropertyDetails.tsx'
import 'bootstrap/dist/js/bootstrap.bundle.min.js';
import NotFoundPage from './pages/NotFoundPage.tsx'
import { ToastContainer } from 'react-toastify'
import Navbar from './components/Navbar.tsx'

const router = createBrowserRouter([
  {
    path: '/',
    element: (
   
        <ProtectedRoute>
        <App />
      </ProtectedRoute>
    ),
  },
  {
    path: '/login',
    element: <Login />,
  },
  {
    path: '/property/:id',
    element:(
      <ProtectedRoute >
        <Navbar/>
        <PropertyDetails />
      </ProtectedRoute>
    ),
  },
  {
    path: '*', 
    element: <NotFoundPage />,
  },
]);

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <AuthProvider>
      <RouterProvider router={router} />
      <ToastContainer
        position="top-right"
        autoClose={3000}
        hideProgressBar={false}
        newestOnTop={true}
        closeOnClick
        pauseOnHover
        draggable
        theme="colored"
      />
    </AuthProvider>
  </StrictMode>,
)

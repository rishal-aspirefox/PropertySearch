import type { PropsWithChildren } from "react";
import { Navigate } from "react-router-dom";
import Cookies from 'js-cookie';
type ProtectedRouteProps = PropsWithChildren 

export default function ProtectedRoute({
  children,
}: ProtectedRouteProps) {
  const authToken = Cookies.get("apiAccessToken");

  if (!authToken) {

    return <Navigate to="/login" replace />;
  }

  return children;
}
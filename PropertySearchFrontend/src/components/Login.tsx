import React, { use, useEffect, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import { Link, useNavigate } from "react-router-dom";

import { useAuth } from "./AuthProvider";
const Login = () => {
  
  const { handleLogin } = useAuth();
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();

  function handleEmailChange(event: React.ChangeEvent<HTMLInputElement>) {
    setEmail(event.target.value);
  }
  function handlePasswordChange(event: React.ChangeEvent<HTMLInputElement>) {
    setPassword(event.target.value);
  }


  async function handleSubmit(event: React.FormEvent<HTMLFormElement>) {
    event.preventDefault();
    const loginPayload = {
      email,
      password,
    };
 
    const isLoginSuccess =  await handleLogin(loginPayload);
     if(isLoginSuccess) navigate("/");
  }


  return (
    <div
      className="vh-100 vw-100 d-flex align-items-center justify-content-center position-relative overflow-hidden"
      style={{ backgroundColor: "#ffffffff" }}
    >
      <div
        className="row w-75 z-1"
        style={{
          maxWidth: "1000px",
          borderRadius: "16px",
          overflow: "hidden",
          backdropFilter: "blur(12px)",
          background: "rgba(255, 255, 255, 0.3)",
          boxShadow: "10px 8px 32px rgba(0,0,0,0.1)",
        }}
      >
        <div id="login-left-side"
          className="col-md-6 d-flex flex-column justify-content-between text-white p-4"
          style={{
            backgroundColor: "var(--bg-black)",
          }}
        >
          <div className="text-end">
          </div>
          <div className="mt-auto">
            <div className="d-flex mt-3">
              <div
                className="me-2 bg-white rounded-pill"
                style={{ width: "10px", height: "10px" }}
              ></div>
              <div
                className="me-2 bg-white rounded-pill"
                style={{ width: "10px", height: "10px" }}
              ></div>
              <div
                className="bg-white rounded-pill"
                style={{ width: "10px", height: "10px" }}
              ></div>
            </div>
          </div>
        </div>

        <div className="col-md-6 p-5 text-black bg-transparent">
          <h3 className="mb-3">Login</h3>
          <form onSubmit={handleSubmit}>
            <div className="mb-3">
              <input
                type="email"
                className="form-control border-dark bg-white text-black rounded-3"
                placeholder="Email"
                onChange={handleEmailChange}
                value={email}
                required
              />
            </div>

            <div className="mb-3">
              <input
                type="password"
                className="form-control border-dark bg-white text-black rounded-3"
                placeholder="Password"
                onChange={handlePasswordChange}
                value={password}
                required
              />
            </div>

            <button
              type="submit"
              className="btn w-100 mb-3"
              style={{
                backgroundColor: "#000",
                color: "#fff",
                borderRadius: "10px",
              }}
            >
              Login
            </button>

            <hr className="text-muted" />

          </form>
        </div>
      </div>
    </div>
  );
};

export default Login;

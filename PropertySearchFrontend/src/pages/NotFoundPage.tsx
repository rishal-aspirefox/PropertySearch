import React from "react";
import { Link } from "react-router-dom";

const NotFoundPage: React.FC = () => {
    return (
        <div className="container-fluid d-flex justify-content-center align-items-center min-vh-100" style={{ backgroundColor: '#f8f9fa' }}>
            <div className="text-center p-5 bg-dark text-white rounded shadow-lg" style={{ width: '100%', maxWidth: '600px' }}>
                <h1 className="display-1 fw-bold">404</h1>
                <p className="fs-4 mb-4">Page Not Found</p>
                <Link to="/" className="btn btn-primary btn-lg">
                    Go Back to Home
                </Link>
            </div>
        </div>
    );
};

export default NotFoundPage;

import { useNavigate } from "react-router-dom";
import Cookies from "js-cookie";

export default function Navbar() {
    const navigate = useNavigate();

    const handleLogout = () => {
        Cookies.remove("apiAccessToken", { path: "/" });
        navigate("/login");
    };

    return (
        <nav
            className="navbar navbar-light bg-white px-3 shadow-sm fixed-top"
            role="navigation"
            aria-label="Main navigation"
        >
            <div className="d-flex justify-content-between align-items-center w-100">
                <div className="d-flex align-items-center w-100">
                    <div className="d-flex align-items-center me-3">
                        <img
                            width={40}
                            src="https://img.icons8.com/?size=100&id=LzEL0wT29b9D&format=png&color=000000"
                            alt="EduMate logo"
                            className="me-2 rounded"
                        />
                        <span
                            className="fw-bold fs-lg-5"
                            aria-label="Property and space application title"
                        >
                            Property and space
                        </span>
                    </div>
                </div>
                <div>
                    <button
                        onClick={handleLogout}
                        className="btn btn-danger btn-sm font-bold"
                        aria-label="Logout button"
                    >
                        Logout
                    </button>
                </div>
            </div>
        </nav>
    );
}

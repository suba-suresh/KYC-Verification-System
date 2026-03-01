import { Routes, Route, Link } from "react-router-dom";
import UserDashboard from "./pages/UserDashboard";
import AdminDashboard from "./pages/AdminDashboard";

function App() {
    return (
        <div>
            <h1>KYC System</h1>

            <nav>
                <Link to="/">User</Link> |{" "}
                <Link to="/admin">Admin</Link>
            </nav>

            <Routes>
                <Route path="/" element={<UserDashboard />} />
                <Route path="/admin" element={<AdminDashboard />} />
            </Routes>
        </div>
    );
}

export default App;
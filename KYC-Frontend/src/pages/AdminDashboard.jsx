import { useEffect, useState } from "react";

function AdminDashboard() {
    const [requests, setRequests] = useState([]);

    useEffect(() => {
        fetch("http://localhost:5001/api/verification")
            .then(res => res.json())
            .then(data => setRequests(data));
    }, []);

    const updateStatus = async (id, status) => {
        await fetch(`http://localhost:5001/api/verification/${id}/status?status=${status}`, {
            method: "PUT"
        });

        // Refresh list
        const updated = await fetch("http://localhost:5001/api/verification");
        const data = await updated.json();
        setRequests(data);
    };

    return (
        <div>
            <h2>Admin Dashboard</h2>

            {requests.map(req => (
                <div key={req.id} style={{ border: "1px solid black", margin: "10px", padding: "10px" }}>
                    <p><strong>Name:</strong> {req.fullName}</p>
                    <p><strong>Document Type:</strong> {req.documentType}</p>
                    <p><strong>Status:</strong> {req.status}</p>

                    {req.status === 0 && (
                        <>
                            <button onClick={() => updateStatus(req.id, 1)}>Approve</button>
                            <button onClick={() => updateStatus(req.id, 2)}>Reject</button>
                        </>
                    )}
                </div>
            ))}
        </div>
    );
}

export default AdminDashboard;
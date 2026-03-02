import { useEffect, useState } from "react";

function AdminDashboard() {
    const [requests, setRequests] = useState([]);
    const [loading, setLoading] = useState(true);

    const fetchRequests = async () => {
        const res = await fetch("http://localhost:5001/api/verification");
        const data = await res.json();
        setRequests(data);
        setLoading(false);
    };

    useEffect(() => {
        fetchRequests();
    }, []);

    const updateStatus = async (id, status) => {
        await fetch(`http://localhost:5001/api/verification/${id}/status?status=${status}`, {
            method: "PUT"
        });

        fetchRequests();
    };

    const getStatusBadge = (status) => {
        switch (status) {
            case 0:
                return <span style={styles.pending}>Pending</span>;
            case 1:
                return <span style={styles.approved}>Approved</span>;
            case 2:
                return <span style={styles.rejected}>Rejected</span>;
            default:
                return null;
        }
    };

    return (
        <div style={styles.container}>
            <h2 style={styles.title}>Admin Dashboard</h2>

            {loading ? (
                <p>Loading requests...</p>
            ) : requests.length === 0 ? (
                <p>No verification requests found.</p>
            ) : (
                <div style={styles.grid}>
                    {requests.map(req => (
                        <div key={req.id} style={styles.card}>
                            <h3>{req.fullName}</h3>
                            <p><strong>Document:</strong> {req.documentType}</p>
                            <p><strong>Status:</strong> {getStatusBadge(req.status)}</p>

                            {req.status === 0 && (
                                <div style={styles.buttonGroup}>
                                    <button
                                        style={styles.approveBtn}
                                        onClick={() => updateStatus(req.id, 1)}
                                    >
                                        Approve
                                    </button>
                                    <button
                                        style={styles.rejectBtn}
                                        onClick={() => updateStatus(req.id, 2)}
                                    >
                                        Reject
                                    </button>
                                </div>
                            )}
                        </div>
                    ))}
                </div>
            )}
        </div>
    );
}

const styles = {
    container: {
        padding: "40px",
        backgroundColor: "#f4f6f9",
        minHeight: "100vh"
    },
    title: {
        marginBottom: "30px"
    },
    grid: {
        display: "grid",
        gridTemplateColumns: "repeat(auto-fill, minmax(280px, 1fr))",
        gap: "20px"
    },
    card: {
        background: "white",
        padding: "20px",
        borderRadius: "10px",
        boxShadow: "0 6px 15px rgba(0,0,0,0.08)"
    },
    buttonGroup: {
        marginTop: "15px",
        display: "flex",
        gap: "10px"
    },
    approveBtn: {
        padding: "8px 12px",
        backgroundColor: "#16a34a",
        color: "white",
        border: "none",
        borderRadius: "6px",
        cursor: "pointer"
    },
    rejectBtn: {
        padding: "8px 12px",
        backgroundColor: "#dc2626",
        color: "white",
        border: "none",
        borderRadius: "6px",
        cursor: "pointer"
    },
    pending: {
        color: "#f59e0b",
        fontWeight: "bold"
    },
    approved: {
        color: "#16a34a",
        fontWeight: "bold"
    },
    rejected: {
        color: "#dc2626",
        fontWeight: "bold"
    }
};

export default AdminDashboard;
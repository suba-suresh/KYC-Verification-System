import { useState } from "react";

function UserDashboard() {
    const [message, setMessage] = useState("");
    const [loading, setLoading] = useState(false);

    const handleSubmit = async (e) => {
        e.preventDefault();
        setLoading(true);
        setMessage("");

        const formData = new FormData(e.target);

        try {
            const response = await fetch("http://localhost:5001/api/verification", {
                method: "POST",
                body: formData
            });

            const data = await response.json();

            setMessage(
                `? Submission Successful! Request ID: ${data.id} | Status: ${data.status}`
            );

            e.target.reset();
        // eslint-disable-next-line no-unused-vars
        } catch (error) {
            setMessage("? Something went wrong. Please try again.");
        }

        setLoading(false);
    };

    return (
        <div style={styles.container}>
            <div style={styles.card}>
                <h2 style={styles.title}>KYC Verification</h2>

                <form onSubmit={handleSubmit} style={styles.form}>
                    <input name="FullName" placeholder="Full Name" required style={styles.input} />
                    <input name="DocumentType" placeholder="Document Type (Passport / Aadhaar)" required style={styles.input} />
                    <input name="DocumentNumber" placeholder="Document Number" required style={styles.input} />

                    <label style={styles.label}>Upload Document</label>
                    <input type="file" name="DocumentFile" required />

                    <label style={styles.label}>Upload Selfie (Optional)</label>
                    <input type="file" name="SelfieFile" />

                    <button type="submit" style={styles.button} disabled={loading}>
                        {loading ? "Submitting..." : "Submit Verification"}
                    </button>
                </form>

                {message && <p style={styles.message}>{message}</p>}
            </div>
        </div>
    );
}

const styles = {
    container: {
        minHeight: "100vh",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
        backgroundColor: "#f4f6f9"
    },
    card: {
        background: "white",
        padding: "30px",
        borderRadius: "12px",
        width: "400px",
        boxShadow: "0 10px 25px rgba(0,0,0,0.1)"
    },
    title: {
        textAlign: "center",
        marginBottom: "20px"
    },
    form: {
        display: "flex",
        flexDirection: "column",
        gap: "12px"
    },
    input: {
        padding: "10px",
        borderRadius: "6px",
        border: "1px solid #ccc"
    },
    label: {
        fontSize: "14px",
        fontWeight: "bold"
    },
    button: {
        marginTop: "10px",
        padding: "12px",
        backgroundColor: "#2563eb",
        color: "white",
        border: "none",
        borderRadius: "6px",
        cursor: "pointer",
        fontWeight: "bold"
    },
    message: {
        marginTop: "15px",
        textAlign: "center",
        fontWeight: "bold"
    }
};

export default UserDashboard;
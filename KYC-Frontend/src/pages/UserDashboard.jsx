import { useState } from "react";

function UserDashboard() {
    const [message, setMessage] = useState("");

    const handleSubmit = async (e) => {
        e.preventDefault();

        const formData = new FormData(e.target);

        const response = await fetch("http://localhost:5001/api/verification", {
            method: "POST",
            body: formData
        });

        const data = await response.json();
        setMessage(`Submission Successful! Request ID: ${data.id} | Status: ${data.status}`);
    };

    return (
        <div>
            <h2>User KYC Verification</h2>

            <form onSubmit={handleSubmit}>
                <input name="FullName" placeholder="Full Name" required />
                <br />

                <input name="DocumentType" placeholder="Document Type" required />
                <br />

                <input name="DocumentNumber" placeholder="Document Number" required />
                <br />

                <input type="file" name="DocumentFile" required />
                <br />

                <input type="file" name="SelfieFile" />
                <br />

                <button type="submit">Submit</button>
            </form>

            <p>{message}</p>
        </div>
    );
}

export default UserDashboard;
document.getElementById("button1").onclick = async () => {
    var url = "http://localhost:5043/cars/GetAllData"

    var req = await fetch(url, {
        method : 'GET',
        headers : {'Content-Type' : 'application/json'}
    })

    var res = await req.json()

    ShowResult(res)
}

function ShowResult(response) {
    if (!Array.isArray(response) || response.length === 0) {
        document.getElementById('root').innerHTML = `
            <div class="alert alert-warning text-center" role="alert">
                No data available.
            </div>
        `;
        return;
    }

    let textContent = `
        <table class="table table-striped table-bordered shadow-sm">
            <thead class="table-dark">
                <tr>
                    <th>ID</th>
                    <th>Brand</th>
                    <th>Type</th>
                    <th>License</th>
                    <th>Date</th>
                </tr>
            </thead>
            <tbody>
    `;

    for (let item of response) {
        textContent += `
            <tr>
                <td>${item.id}</td>
                <td>${item.brand}</td>
                <td>${item.type}</td>
                <td>${item.license}</td>
                <td>${item.date}</td>
            </tr>
        `;
    }

    textContent += `
            </tbody>
        </table>
    `;

    document.getElementById('root').innerHTML = textContent;
}
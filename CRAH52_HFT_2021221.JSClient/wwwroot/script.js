let clubss = [];

fetch('http://localhost:30907/clubs')
    .then(x => x.json())
    .then(y => {
        clubss = y;
        console.log(clubss);
        display();
    });

function display() {
    clubss.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.clubID + "</td><td>"
            + t.clubName + "</td></tr>";

    });
}
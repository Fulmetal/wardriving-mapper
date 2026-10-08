window.initMap = function (elementId, lat, lng, zoom) {
    var map = L.map(elementId).setView([lat, lng], zoom);

    var streets = L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; OpenStreetMap'
    });

    var satellite = L.tileLayer(
        'https://server.arcgisonline.com/ArcGIS/rest/services/World_Imagery/MapServer/tile/{z}/{y}/{x}', {
        attribution: 'Esri World Imagery',
        maxZoom: 19
    });

    var places = L.tileLayer(
        'https://server.arcgisonline.com/ArcGIS/rest/services/Reference/World_Boundaries_and_Places/MapServer/tile/{z}/{y}/{x}', {
            attribution: 'Esri Reference',
            maxZoom: 19
        });

    var transportation = L.tileLayer(
        'https://server.arcgisonline.com/ArcGIS/rest/services/Reference/World_Transportation/MapServer/tile/{z}/{y}/{x}', {
            attribution: 'Esri Transportation',
            maxZoom: 19
        }
    );

    var hybrid = L.layerGroup([satellite, places, transportation]);

    var baseMaps = { "Street": streets, "Satellite": satellite, "Hybrid": hybrid };
    L.control.layers(baseMaps).addTo(map);
    streets.addTo(map);
    return map;
}; 

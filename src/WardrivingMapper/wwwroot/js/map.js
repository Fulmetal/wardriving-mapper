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

    var baseMaps = { "Street": streets, "Satellite": satellite };
    L.control.layers(baseMaps).addTo(map);
    streets.addTo(map);
    return map;
};   

<%@ Page Title="Mapa" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="Mapa.aspx.cs" Inherits="Tupa_Web.View.Mapa.Mapa" 
    MetaKeywords="NoFooter"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/Content/Css/mapa.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container_wrapper dashboard">
        <div class="inputs">
             <div class="routes card" onclick="ToogleDirections();">
                <span class="material-icons">
                directions
                </span>
            </div>
            <div class="search" id="searchBoxContainer">
                <label for="search">
                    <span class="material-icons">
                    search
                    </span>
                </label>
                
                <input id="txtSearch" type="text" name="search" id="search" placeholder="Pesquisar..." class="card">
            </div>
        </div>

        <div class="buttons">
            <div class="current-location card button" onclick="CenterMap();">
                <span class="material-icons">
                gps_fixed
                </span>
            </div>
            <div class="zoom button card">
                <div onclick="moreZoom();">
                    <span class="material-icons">
                    add
                    </span>
                </div>
                <div onclick="minusZoom();">
                    <span class="material-icons">
                    remove
                    </span>
                </div>
            </div>
        </div>
    </div>  
    
    <div class="directionsContainer disabled">
        <div id="directionsPanel"></div>
        <div id="directionsItinerary"></div>
    </div>
    <div class="buttonClose card disabled icon" onclick="ToogleDirections();">
        <span class="material-icons-outlined">
        close
        </span>
    </div>

    <div id="myMap"></div>

    <template id="customInfobox">
        <div class="customInfobox card">
            <h2>{title}</h2>

            <div class="description">
                <p>{description}</p>
            </div>

            <a class="primary-button" href="{link}">Mais informações</a>
        </div>
    </template>

    <template id="customInfoboxNoButton">
        <div class="customInfobox card">
            <h2>{title}</h2>
        </div>
    </template>

    <template id="tooltipTemplate">
        <div>
            <p>{title}</p>
        </div>
    </template>

    <input type="hidden" id="jsonPontosDeRisco" name="jsonPontosDeRisco" value='[{"id":"1aa89a49-b2f3-4b0b-864c-40c9e27bdbf0","descricao":"Avenida Santo Amaro","ponto":{"id":"c0093e38-1524-4e7e-a5e1-f3dba5b5f2a5","latitude":-23.626077715193002,"longitude":-46.68722756134409,"count":0},"distrito":{"id":"fe0c6524-df33-439e-b9c8-40e476d2a6d7","cidade":{"id":"588ca882-b485-4ea4-8254-fb5e5f6075b7","estado":{"id":"554449d7-4064-437b-811c-7acce3d695ae","pais":{"id":"dd9cff52-8a26-4e93-a50d-a9469c6fbea5","nome":"Brasil","sigla":"BR"},"nome":"São Paulo","sigla":"SP"},"nome":"São Paulo"},"nome":"Santo Amaro"}},{"id":"28cd3813-b1c4-4fa4-a2e2-bc858027bb66","descricao":"Rua Maria Antonia","ponto":{"id":"4987d6ee-9f07-4312-a81d-5fd6d8b8978e","latitude":-23.546291599953275,"longitude":-46.65101229874567,"count":0},"distrito":{"id":"b4b6e3fd-0588-4028-bd88-0d3740f97c89","cidade":{"id":"588ca882-b485-4ea4-8254-fb5e5f6075b7","estado":{"id":"554449d7-4064-437b-811c-7acce3d695ae","pais":{"id":"dd9cff52-8a26-4e93-a50d-a9469c6fbea5","nome":"Brasil","sigla":"BR"},"nome":"São Paulo","sigla":"SP"},"nome":"São Paulo"},"nome":"Consolação"}},{"id":"6038a4dd-8fca-4af7-9771-68baaef9e984","descricao":"Rua Caio Prado","ponto":{"id":"a7fcbe9a-6a47-4e95-a830-f4f4d010d04f","latitude":-23.549035278846254,"longitude":-46.64859688222123,"count":0},"distrito":{"id":"b4b6e3fd-0588-4028-bd88-0d3740f97c89","cidade":{"id":"588ca882-b485-4ea4-8254-fb5e5f6075b7","estado":{"id":"554449d7-4064-437b-811c-7acce3d695ae","pais":{"id":"dd9cff52-8a26-4e93-a50d-a9469c6fbea5","nome":"Brasil","sigla":"BR"},"nome":"São Paulo","sigla":"SP"},"nome":"São Paulo"},"nome":"Consolação"}},{"id":"69eceb03-1a97-458d-926d-47cbc5f08872","descricao":"Avenida Professor Luiz Ignácio Anhaia Mello","ponto":{"id":"cde09024-14b3-4a3e-9be0-419fc8bd7d5e","latitude":-23.581698347704315,"longitude":-46.56167553310564,"count":0},"distrito":{"id":"d8260437-84e8-4b2a-8fbb-7d1dc4a17b27","cidade":{"id":"588ca882-b485-4ea4-8254-fb5e5f6075b7","estado":{"id":"554449d7-4064-437b-811c-7acce3d695ae","pais":{"id":"dd9cff52-8a26-4e93-a50d-a9469c6fbea5","nome":"Brasil","sigla":"BR"},"nome":"São Paulo","sigla":"SP"},"nome":"São Paulo"},"nome":"Vila Prudente"}},{"id":"6f4f0527-d248-4c4b-96a5-a24666112ac5","descricao":"Avenida Antônio Munhoz Bonilha","ponto":{"id":"74794820-490c-4bd1-b995-bc142c0c2acc","latitude":-23.499512255206376,"longitude":-46.683796270303695,"count":0},"distrito":{"id":"c22385db-78ca-418b-95c2-9e126481ff09","cidade":{"id":"588ca882-b485-4ea4-8254-fb5e5f6075b7","estado":{"id":"554449d7-4064-437b-811c-7acce3d695ae","pais":{"id":"dd9cff52-8a26-4e93-a50d-a9469c6fbea5","nome":"Brasil","sigla":"BR"},"nome":"São Paulo","sigla":"SP"},"nome":"São Paulo"},"nome":"Limão"}},{"id":"b6e1ac06-2ff5-46be-a697-2e7d51a2a310","descricao":"Avenida Celso Garcia","ponto":{"id":"b75ca9c9-4dce-4030-88cb-e37d45e55334","latitude":-23.53666103385123,"longitude":-46.58914367537825,"count":0},"distrito":{"id":"3e892405-8884-4752-9808-12487dc34226","cidade":{"id":"588ca882-b485-4ea4-8254-fb5e5f6075b7","estado":{"id":"554449d7-4064-437b-811c-7acce3d695ae","pais":{"id":"dd9cff52-8a26-4e93-a50d-a9469c6fbea5","nome":"Brasil","sigla":"BR"},"nome":"São Paulo","sigla":"SP"},"nome":"São Paulo"},"nome":"Belém"}},{"id":"d04e8a18-1a3b-4c11-ba7f-6b70a4d3c61a","descricao":"Avenida Marquês de São Vicente","ponto":{"id":"589a3532-7231-4787-aaba-c40d546b883e","latitude":-23.519291936748548,"longitude":-46.6746502960441,"count":0},"distrito":{"id":"851df22a-60cb-4a32-823b-24d79ee36024","cidade":{"id":"588ca882-b485-4ea4-8254-fb5e5f6075b7","estado":{"id":"554449d7-4064-437b-811c-7acce3d695ae","pais":{"id":"dd9cff52-8a26-4e93-a50d-a9469c6fbea5","nome":"Brasil","sigla":"BR"},"nome":"São Paulo","sigla":"SP"},"nome":"São Paulo"},"nome":"Barra Funda"}},{"id":"dbe658b2-fdb1-4e01-b721-720e8df63166","descricao":"Rua São Francisco","ponto":{"id":"f54c3ed2-b52e-495c-aa86-ba1253c65d7f","latitude":-23.549059644370665,"longitude":-46.63796092457814,"count":0},"distrito":{"id":"cbe6eb41-cc32-455b-92c1-8086333e1cc4","cidade":{"id":"588ca882-b485-4ea4-8254-fb5e5f6075b7","estado":{"id":"554449d7-4064-437b-811c-7acce3d695ae","pais":{"id":"dd9cff52-8a26-4e93-a50d-a9469c6fbea5","nome":"Brasil","sigla":"BR"},"nome":"São Paulo","sigla":"SP"},"nome":"São Paulo"},"nome":"Sé"}},{"id":"35185bf5-b83d-4d28-af1b-4df6a6fb05da","descricao":"Avenida do Estado","ponto":{"id":"84fddd49-d641-4383-80c3-d6368b7c266b","latitude":-23.55043198166717,"longitude":-46.626502326549996,"count":0},"distrito":null},{"id":"35dbb228-cc90-4067-bb71-11f6b9df0e34","descricao":"Avenida Aricanduva","ponto":{"id":"567959b4-4c84-4615-9d65-31b3d6b908ec","latitude":-23.5637057,"longitude":-46.5136243,"count":0},"distrito":null},{"id":"4d6453a6-9918-47d6-98b4-dbfcf0b47b3e","descricao":"Corredor Norte-Sul","ponto":{"id":"63665f3a-f401-4f0b-adce-79c202e8d043","latitude":-23.5488099,"longitude":-46.639034,"count":0},"distrito":null},{"id":"57a49037-41b3-481a-a4a5-37a97668bbaf","descricao":"Marginal Pinheiros","ponto":{"id":"603d9ec5-6414-4dfd-98ef-87a6ead76366","latitude":-23.5652793,"longitude":-46.7027212,"count":0},"distrito":null},{"id":"5e930a9c-4d8f-4d1b-aafa-5184a5c01435","descricao":"Avenida Sumaré","ponto":{"id":"5ee3b220-f45d-4c57-ae0d-f6fc73cd3957","latitude":-23.5291898,"longitude":-46.6791973,"count":0},"distrito":null},{"id":"787574ea-c5a0-413e-b5ad-acdfe69572e5","descricao":"Rua Ricardo Cavatton","ponto":{"id":"ed263508-bf1b-424a-9f2b-caa1f1f14fb4","latitude":-23.51154577099006,"longitude":-46.702789758619346,"count":0},"distrito":null},{"id":"91b6d73f-9f8d-406e-98ce-3b2b8ac98a37","descricao":"Marginal Pinheiros","ponto":{"id":"c3e220f1-ea95-43f0-b8b1-1757522f1e4e","latitude":-23.593279141769965,"longitude":-46.694204159345865,"count":0},"distrito":null},{"id":"a8eaf912-02dd-4e10-bc8b-7df8f3571463","descricao":"Avenida Alcântara Machado","ponto":{"id":"2d707ca4-f037-4ee9-805d-eda07414ab4d","latitude":-23.54435799265057,"longitude":-46.5931803832838,"count":0},"distrito":null},{"id":"de152d60-41d2-453d-b3fc-cadf725937fa","descricao":"Avenida Professor Abraão de Morais","ponto":{"id":"2cdce908-3786-44fb-9589-bec51b7b2173","latitude":-23.61844814506177,"longitude":-46.62820989239213,"count":0},"distrito":null}]'>
    
    <script type='text/javascript' src='https://www.bing.com/api/maps/mapcontrol?callback=GetMap&key=Ari-cml8va4SytOAMFM4bXFT6r_AvY2Q9ueyPK2wh8SplYx5_4fpC0AtEN5Qpb21' async defer></script>

    <script type="text/javascript">
        var map, infobox

        let infoboxTemplate = ''
        let infoboxTemplateNoButton = ''
        let tooltipTemplate = ''

        if ('content' in document.createElement('template')) {
            infoboxTemplate = document.querySelector('#customInfobox').innerHTML.toString()
            infoboxTemplateNoButton = document.querySelector('#customInfoboxNoButton').innerHTML.toString()
        }

        const myStyleWhite = {
            "version": "1.0",
            "settings": {
                "landColor": "#e7e6e5",
                "shadedReliefVisible": false
            },
            "elements": {
                "vegetation": {
                    "fillColor": "#c5dea2"
                },
                "naturalPoint": {
                    "visible": false,
                    "labelVisible": false
                },
                "transportation": {
                    "labelOutlineColor": "#ffffff",
                    "fillColor": "#ffffff",
                    "strokeColor": "#d7d6d5"
                },
                "water": {
                    "fillColor": "#b1bdd6",
                    "labelColor": "#ffffff",
                    "labelOutlineColor": "#9aa9ca"
                },
                "structure": {
                    "fillColor": "#d7d6d5"
                },
                "indigenousPeoplesReserve": {
                    "visible": false
                },
                "military": {
                    "visible": false
                }
            }
        }

        function GetMap() {
            map = new Microsoft.Maps.Map('#myMap', {
                showDashboard: false,
                showScalebar: false,
                customMapStyle: myStyleWhite
            })

            CenterMap()

            Microsoft.Maps.loadModule('Microsoft.Maps.AutoSuggest', function () {
                var manager = new Microsoft.Maps.AutosuggestManager({ map: map });
                manager.attachAutosuggest('#txtSearch', '#searchBoxContainer', selectedSuggestion);
            });

            LoadPontosRiscos();

            //Load the directions module.
            Microsoft.Maps.loadModule('Microsoft.Maps.Directions', function () {
                //Create an instance of the directions manager.
                directionsManager = new Microsoft.Maps.Directions.DirectionsManager(map);

                //Specify where to display the route instructions.
                directionsManager.setRenderOptions({ itineraryContainer: '#directionsItinerary' });

                //Specify the where to display the input panel
                directionsManager.showInputPanel('directionsPanel');
            });
        }

        function LoadPontosRiscos() {
            let center = map.getCenter();

            //Create an infobox for displaying detailed information.
            infobox = new Microsoft.Maps.Infobox(center, {
                visible: false,
                showPointer: false,
                showCloseButton: false,
                offset: new Microsoft.Maps.Point(0, -156)
            })

            infobox.setMap(map)

            let jsonPontosDeRisco = JSON.parse(document.querySelector('#jsonPontosDeRisco').value)

            for (var i = 0; i < jsonPontosDeRisco.length; i++) {
                var pin = new Microsoft.Maps.Pushpin(jsonPontosDeRisco[i].ponto, {
                    icon: '/Content/Images/location.svg',
                    anchor: new Microsoft.Maps.Point(28, 56)
                })

                if (jsonPontosDeRisco[i].distrito != null) {
                    //Store some metadata with the pushpin.
                    pin.metadata = {
                        title: jsonPontosDeRisco[i].distrito.nome + ', ' + jsonPontosDeRisco[i].distrito.cidade.nome + ' - ' + jsonPontosDeRisco[i].distrito.cidade.estado.sigla,
                        description: jsonPontosDeRisco[i].descricao
                    }
                } else {
                    //Store some metadata with the pushpin.
                    pin.metadata = {
                        title: jsonPontosDeRisco[i].descricao,
                        description: ''
                    }
                }

                //Add a mouse events to the pushpin.
                Microsoft.Maps.Events.addHandler(pin, 'click', pushpinClicked)
                Microsoft.Maps.Events.addHandler(pin, 'mouseover', pushpinHovered)
                Microsoft.Maps.Events.addHandler(pin, 'mouseout', closeInfobox)

                //Add pushpin to the map.
                map.entities.push(pin)
            }
        }

        function selectedSuggestion(result) {
            //Remove previously selected suggestions from the map.
            map.entities.clear();

            //Show the suggestion as a pushpin and center map over it.
            var pin = new Microsoft.Maps.Pushpin(result.location);
            map.entities.push(pin);
            map.setView({ bounds: result.bestView });

            LoadPontosRiscos();
        }

        function CenterMap() {
            //Request the user's location
            navigator.geolocation.getCurrentPosition(function (position) {
                var loc = new Microsoft.Maps.Location(
                    position.coords.latitude,
                    position.coords.longitude);

                //Remove previously selected suggestions from the map.
                map.entities.clear();

                //Center the map on the user's location.
                map.setView({ center: loc, zoom: 15 });

                //Show the suggestion as a pushpin and center map over it.
                var pin = new Microsoft.Maps.Pushpin(loc);
                map.entities.push(pin);

                LoadPontosRiscos();
            });
        }

        function pushpinClicked(e) {
            //Hide the tooltip
            closeInfobox()

            //Make sure the infobox has metadata to display.
            if (e.target.metadata) {
                if (e.target.metadata.description != "") {
                    //Set the infobox options with the metadata of the pushpin.
                    infobox.setOptions({
                        htmlContent: infoboxTemplate
                            .replace('{title}', e.target.metadata.title)
                            .replace('{description}', e.target.metadata.description)
                            .replace('{link}', 'https://tupaweb.azurewebsites.net/Dashboard/Hora?q=' + e.target.metadata.title),
                        location: e.target.getLocation(),
                        title: e.target.metadata.title,
                        description: e.target.metadata.description,
                        visible: true
                    })
                } else {
                    //Set the infobox options with the metadata of the pushpin.
                    infobox.setOptions({
                        htmlContent: infoboxTemplateNoButton
                            .replace('{title}', e.target.metadata.title),
                        location: e.target.getLocation(),
                        title: e.target.metadata.title,
                        description: e.target.metadata.description,
                        visible: true
                    })
                }                
            }
        }

        function pushpinHovered(e) {
            //Hide the infobox
            closeInfobox()
        }

        function closeInfobox() {
            //Hide the infobox
            infobox.setOptions({ visible: false })
        }

        function moreZoom() {
            lastZoomLevel = map.getZoom()
            lastZoomLevel++

            map.setView({ center: map.getCenter(), zoom: lastZoomLevel });
        }

        function minusZoom() {
            lastZoomLevel = map.getZoom()
            lastZoomLevel--

            map.setView({ center: map.getCenter(), zoom: lastZoomLevel });
        }

        function ToogleDirections() {
            let inputs = document.querySelector('.inputs')
            let directions = document.querySelector('.directionsContainer')
            let closeButton = document.querySelector('.buttonClose')

            inputs.classList.toggle('disabled')
            directions.classList.toggle('disabled')
            closeButton.classList.toggle('disabled')
        }
    </script>
</asp:Content>

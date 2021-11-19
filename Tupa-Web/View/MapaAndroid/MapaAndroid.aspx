<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MapaAndroid.aspx.cs" Inherits="Tupa_Web.View.MapaAndroid.MapaAndroid" %>

<!DOCTYPE html>

<html lang="pt-br">
<head runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="TupaWeb">

    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <meta name="theme-color" content="#2485F3">

    <meta property="og:title" content="Tupã: Previsões, alertas e mapas meteorologicos">
    <meta property="og:image" content="https://guilhermeivo.github.io/tcc-web-design/content/tupa-social.png">
    <meta property="og:description" content="Alertas de enchentes em locais de risco e alterações climáticas, com monitoriamento da sua localização atual ou regiões salvadas como favoritas.">
    <meta property="og:url" content="https://guilhermeivo.github.io/tcc-web-design/">

    <meta name="twitter:card" content="summary_large_image">
    <meta name="twitter:url" content="https://guilhermeivo.github.io/tcc-web-design/">
    <meta name="twitter:title" content="Tupã: Previsões, alertas e mapas meteorologicos">
    <meta name="twitter:description" content="Alertas de enchentes em locais de risco e alterações climáticas, com monitoriamento da sua localização atual ou regiões salvadas como favoritas.">
    <meta name="twitter:image" content="https://guilhermeivo.github.io/tcc-web-design/content/tupa-social.png">

    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@400;500&display=swap" rel="stylesheet">    
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans:wght@400;600&display=swap" rel="stylesheet">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons|Material+Icons+Outlined|" rel="stylesheet">

    <link rel="stylesheet" href="/Content/Css/reset.css">
    <link rel="stylesheet" href="/Content/Css/main.css">
    <link rel="stylesheet" href="/Content/Css/variables.css">
    <link rel="stylesheet" href="/Content/Css/loading.css">
    <link rel="stylesheet" href="/Content/Css/mapa.css">

    <title>Mapa Android</title>

    <style>

        .MicrosoftMap.dirSDK .directionsPanel {    
            margin-left: 0;
            padding-top: 12px
        }

        #myMap {
            height: 100vh;
            top: 0;
        }

        .directionsContainer {
            width: 100%;
            height: 100vh;
            top: 0 !important;
            z-index: 1000;
        }

        .buttonClose {
            left: initial;
            right: 12px;
            bottom: 12px;
            top: initial;
            z-index: 1001;
        }

        .search {
            width: calc(100% - 140px);
        }

        .inputs {
            margin: 12px 0
        }

        .dashboard {
            min-height: 100vh;
        }

        .dashboard .buttons {
            bottom: 12px;
            right: 12px;
            padding: 24px 0;
        }

        .zoom > div {
            margin: 6px 0
        }

        .CopyrightContainer  {
            display: none
        }

        .MicrosoftMap .ShadowTextDark {
            color: #00000000 !important;
            text-shadow: #00000000 1px 1px !important;
            pointer-events: none;
        }

        .MicrosoftMap .ShadowTextDark span {
            pointer-events: none;
            color: #00000000 !important;
            text-shadow: #00000000 1px 1px !important;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
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

        <div id="myMap" style="height: 100vh; top: 0;"></div>

        <script type='text/javascript' src='https://www.bing.com/api/maps/mapcontrol?callback=GetMap&key=Ari-cml8va4SytOAMFM4bXFT6r_AvY2Q9ueyPK2wh8SplYx5_4fpC0AtEN5Qpb21' async defer></script>

        <script type="text/javascript">
            var map

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

            function selectedSuggestion(result) {
                //Remove previously selected suggestions from the map.
                map.entities.clear();

                //Show the suggestion as a pushpin and center map over it.
                var pin = new Microsoft.Maps.Pushpin(result.location);
                map.entities.push(pin);
                map.setView({ bounds: result.bestView });
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
    </form>
</body>
</html>

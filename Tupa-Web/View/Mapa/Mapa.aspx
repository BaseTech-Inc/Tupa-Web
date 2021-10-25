<%@ Page Title="Mapa" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="Mapa.aspx.cs" Inherits="Tupa_Web.View.Mapa.Mapa" 
    MetaKeywords="NoFooter"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/Content/Css/mapa.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container_wrapper">
        <div class="search">
            <label for="search">
                <span class="material-icons">
                search
                </span>
            </label>
                
            <input id="txtSearch" type="text" name="search" id="search" placeholder="Pesquisar..." class="card">
        </div>
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

    <template id="tooltipTemplate">
        <div>
            <p>{title}</p>
        </div>
    </template>

    <input type="hidden" id="jsonPontosDeRisco" name="jsonPontosDeRisco" value='[{"id":"03a94f55-93a7-4813-841f-be0f99771768","descricao":"Rua Ricardo Cavatton","ponto":{"id":"1fb9e5cb-c6b5-4f0c-8c48-9d74952a03c9","latitude":-23.51154577099006,"longitude":-46.702789758619346,"count":0}},{"id":"190feab4-1d23-4c26-9eed-b231a6b376fd","descricao":"Avenida Santo Amaro","ponto":{"id":"c3dfdbf2-22f2-480e-9bb0-6d714ee51cf2","latitude":-23.626077715193002,"longitude":-46.68722756134409,"count":0}},{"id":"19c963ec-685c-4bfb-aa71-f2c1e6ffbdb0","descricao":"Avenida Alcântara Machado","ponto":{"id":"174a6e82-b129-45bb-bfbe-531c55d92588","latitude":-23.54435799265057,"longitude":-46.5931803832838,"count":0}},{"id":"1ed79f17-aed6-4d3e-8137-89e0a80746d8","descricao":"Avenida Marquês de São Vicente","ponto":{"id":"a2656133-0dea-4803-b624-da0c36d8fb1b","latitude":-23.519291936748548,"longitude":-46.6746502960441,"count":0}},{"id":"228d8ac1-b88e-4f51-8f66-d4e9aa1883ab","descricao":"Avenida Professor Luiz Ignácio Anhaia Mello","ponto":{"id":"a0d959a0-8409-48d7-905c-7eede0498311","latitude":-23.581698347704315,"longitude":-46.56167553310564,"count":0}},{"id":"55a92e5e-82a6-4127-8e82-532594803579","descricao":"Rua Caio Prado","ponto":{"id":"95d42934-9d59-4727-bada-f9785941db66","latitude":-23.549035278846254,"longitude":-46.64859688222123,"count":0}},{"id":"580f8ff9-c8b0-40c8-aa01-3c6ed520a0a4","descricao":"Avenida Professor Abraão de Morais","ponto":{"id":"8a6975dd-3fb6-47cd-b5ce-419b7e88a8bf","latitude":-23.61844814506177,"longitude":-46.62820989239213,"count":0}},{"id":"59c9448c-660a-4231-a838-fc195b3e9f8f","descricao":"Rua São Francisco","ponto":{"id":"48e69eed-8654-4bff-8d26-3f07103e6914","latitude":-23.549059644370665,"longitude":-46.63796092457814,"count":0}},{"id":"6142b76a-f439-4816-8f31-0f0f953f2b81","descricao":"Avenida Aricanduva","ponto":{"id":"c3a659b9-7f03-4e74-b3e3-3ce59a57d59a","latitude":-23.5637057,"longitude":-46.5136243,"count":0}},{"id":"6a294f75-d519-4042-b803-a33b280c1cc3","descricao":"Avenida do Estado","ponto":{"id":"4b6f4114-c1f8-4ffa-bd0e-c1412c1ab7c5","latitude":-23.55043198166717,"longitude":-46.626502326549996,"count":0}},{"id":"6a7a78f6-7122-4018-9592-f762f4475a2c","descricao":"Avenida Celso Garcia","ponto":{"id":"09ed87ad-2d97-4760-a978-59f3b919b146","latitude":-23.53666103385123,"longitude":-46.58914367537825,"count":0}},{"id":"7c478c20-a641-4ceb-8fef-b9497cb575d2","descricao":"Avenida Sumaré","ponto":{"id":"63b64d8a-d050-4153-aa76-c22b54dd9d65","latitude":-23.5291898,"longitude":-46.6791973,"count":0}},{"id":"9b4b2f6c-44cf-419c-b4d2-63dd033226d4","descricao":"Corredor Norte-Sul","ponto":{"id":"2ae8858d-a3ab-47ef-8687-533c02e82b5d","latitude":-23.5488099,"longitude":-46.639034,"count":0}},{"id":"afcce596-3a3e-4b0b-8d8d-3b8943dccfaa","descricao":"Marginal Pinheiros","ponto":{"id":"bea3d7d7-f0b2-49b2-94a6-c67fdf6b9cdc","latitude":-23.593279141769965,"longitude":-46.694204159345865,"count":0}},{"id":"c435e5d5-9b49-4567-931a-3fd3d805bc00","descricao":"Avenida Antônio Munhoz Bonilha","ponto":{"id":"e536d724-2089-4029-9cbc-fd63f2788e48","latitude":-23.499512255206376,"longitude":-46.683796270303695,"count":0}},{"id":"d2a6bc33-a523-4402-a99a-350055cf60b6","descricao":"Rua Maria Antonia","ponto":{"id":"b7c836d4-0920-484c-88f7-b57b55609d31","latitude":-23.546291599953275,"longitude":-46.65101229874567,"count":0}},{"id":"dcbf8198-d868-4d2a-970e-ae07c0db83aa","descricao":"Marginal Pinheiros","ponto":{"id":"cfbcfdf3-037c-48be-92da-62e49c7e3903","latitude":-23.5652793,"longitude":-46.7027212,"count":0}}]'>
    
    <script type='text/javascript' src='https://www.bing.com/api/maps/mapcontrol?callback=GetMap&key=Ari-cml8va4SytOAMFM4bXFT6r_AvY2Q9ueyPK2wh8SplYx5_4fpC0AtEN5Qpb21' async defer></script>

    <script type="text/javascript">
        var map, infobox

        let infoboxTemplate = ''
        let tooltipTemplate = ''

        if ('content' in document.createElement('template')) {
            infoboxTemplate = document.querySelector('#customInfobox').innerHTML.toString()
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

            //Request the user's location
            navigator.geolocation.getCurrentPosition(function (position) {
                var loc = new Microsoft.Maps.Location(
                    position.coords.latitude,
                    position.coords.longitude);

                //Center the map on the user's location.
                map.setView({ center: loc, zoom: 15 });
            });

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

                //Store some metadata with the pushpin.
                pin.metadata = {
                    title: 'Casa Verde - SP',
                    description: jsonPontosDeRisco[i].descricao
                }

                //Add a mouse events to the pushpin.
                Microsoft.Maps.Events.addHandler(pin, 'click', pushpinClicked)
                Microsoft.Maps.Events.addHandler(pin, 'mouseover', pushpinHovered)
                Microsoft.Maps.Events.addHandler(pin, 'mouseout', closeInfobox)

                //Add pushpin to the map.
                map.entities.push(pin)
            }
        }

        function pushpinClicked(e) {
            //Hide the tooltip
            closeInfobox()

            //Make sure the infobox has metadata to display.
            if (e.target.metadata) {
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
    </script>
</asp:Content>

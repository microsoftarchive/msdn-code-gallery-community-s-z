
$(function() {

    var stage = new Kinetic.Stage({
        container: 'container',
        width: 800,
        height: 600,
        draggable: true
    });

    var layer = new Kinetic.Layer();

    //var circle = new Kinetic.Circle({
    //    x: stage.getWidth() / 2,
    //    y: stage.getHeight() / 2,
    //    radius: 70,
    //    fill: 'red',
    //    stroke: 'black',
    //    strokeWidth: 4,
    //    draggable: true
    //});

    //var square = new Kinetic.Rect({
    //    x: stage.getWidth() / 2,
    //    y: stage.getHeight() / 2,
    //    width: 70,
    //    height: 120,
    //    fill: 'green',
    //    stroke: 'black',
    //    strokeWidth: 4,
    //    draggable: true
    //});

    //// add the shape to the layer
    //layer.add(circle);
    //layer.add(square);

    // add the layer to the stage
    stage.add(layer);

    //var imageObj = new Image();
    //imageObj.onload = function() {
    //    var yoda = new Kinetic.Image({
    //        x: 200,
    //        y: 50,
    //        image: imageObj,
    //        width: 106,
    //        height: 118,
    //        draggable: true
    //    });

    //    // add the shape to the layer
    //    layer.add(yoda);

    //    // add the layer to the stage
    //    stage.add(layer);
    //};
    //imageObj.src = 'http://www.html5canvastutorials.com/demos/assets/yoda.jpg';

    /************* ADD Image from DOM ********************/

    $("#makeImg").click(function() {

        var canv = layer.getParent().hitCanvas.context.canvas;
        var canvImg = canv.toDataURL("image/png");
        $("#showImg").attr('src', canvImg);
    });


    var dragSrcEl = null;
    var con = stage.getContainer();
    var imageObjX;
    
    $('body').on('dragstart', "img", function (e) {
        dragSrcEl = this;
    });
    
    con.addEventListener('dragover',function(e){
        e.preventDefault(); //@important
    });
    
    //insert image to stage
    con.addEventListener('drop', function(e) {
        var image = new Kinetic.Image({
            draggable: true
        });
        layer.add(image);
        imageObjX = new Image();
        imageObjX.src = dragSrcEl.src;
        imageObjX.onload = function() {
            image.setImage(imageObjX);
            layer.draw();
        };

        //checkChildren(layer, image);
        try {
            image.on('click', function(ev) {
                var img = this;
                checkChildren(img);
            });
        } catch(ex) {
        }
    });

    function checkChildren(newImg) {
        var children = [];
        var list = [];

        if (layer.children) {
            children = layer.getChildren();
        }

        $(children).each(function(idx, val) {
            list.push(this);
        });

        newImg.parent.removeChildren();
        
        for (var j = 0; j < list.length; j++) {
            if (list[j] != newImg) {
                layer.add(list[j]);
            }
        }
        layer.add(newImg);
        layer.draw();
    }

});



/************************** MONKEY IMAGE OVER DEMO ****************************
function writeMessage(messageLayer, message) {
        var context = messageLayer.getContext();
        messageLayer.clear();
        context.font = '18pt Calibri';
        context.fillStyle = 'black';
        context.fillText(message, 10, 25);
      }
      function loadImages(sources, callback) {
        var assetDir = 'http://www.html5canvastutorials.com/demos/assets/';
        var images = {};
        var loadedImages = 0;
        var numImages = 0;
        for(var src in sources) {
          numImages++;
        }
        for(var src in sources) {
          images[src] = new Image();
          images[src].onload = function() {
            if(++loadedImages >= numImages) {
              callback(images);
            }
          };
          images[src].src = assetDir + sources[src];
        }
      }
      function initStage(images) {
        var stage = new Kinetic.Stage({
          container: 'container',
          width: 578,
          height: 200
        });

        var shapesLayer = new Kinetic.Layer();
        var messageLayer = new Kinetic.Layer();

        var monkey = new Kinetic.Image({
          image: images.monkey,
          x: 120,
          y: 50
        });

        var lion = new Kinetic.Image({
          image: images.lion,
          x: 280,
          y: 30
        });

        monkey.on('mouseover', function() {
          writeMessage(messageLayer, 'mouseover monkey');
        });

        monkey.on('mouseout', function() {
          writeMessage(messageLayer, '');
        });

        lion.on('mouseover', function() {
          writeMessage(messageLayer, 'mouseover lion');
        });

        lion.on('mouseout', function() {
          writeMessage(messageLayer, '');
        });

        lion.createImageHitRegion(function() {
          shapesLayer.draw();
        });

        shapesLayer.add(monkey);
        shapesLayer.add(lion);
        stage.add(shapesLayer);
        stage.add(messageLayer);
      }
      var sources = {
        lion: 'lion.png',
        monkey: 'monkey.png'
      };
      loadImages(sources, initStage);

*****************************************/

/************** FLOWER DEMO *******************

var stage = new Kinetic.Stage({
    container: 'container',
    width: 578,
    height: 200
});

var lineLayer = new Kinetic.Layer();
var flowerLayer = new Kinetic.Layer();

var flower = new Kinetic.Group({
    x: stage.getWidth() / 2,
    y: stage.getHeight() / 2,
    draggable: true
});

// build stem
var stem = new Kinetic.Line({
    strokeWidth: 10,
    stroke: 'green',
    points: [{
        x: flower.getX(),
        y: flower.getY()
    }, {
        x: stage.getWidth() / 2,
        y: stage.getHeight() + 10
    }]
});

// build center
var center = new Kinetic.Circle({
    x: 0,
    y: 0,
    radius: 20,
    fill: 'yellow',
    stroke: 'black',
    strokeWidth: 4
});

center.on('mouseover', function () {
    this.setFill('orange');
    flowerLayer.draw();
    document.body.style.cursor = 'pointer';
});

center.on('mouseout', function () {
    this.setFill('yellow');
    flowerLayer.draw();
    document.body.style.cursor = 'default';
});
// build petals
var numPetals = 10;
for (var n = 0; n < numPetals; n++) {
    // induce scope
    (function () {
        
         //* draw custom shape because KineticJS
         //* currently does not support tear drop
         //* geometries
         
        var petal = new Kinetic.Shape({
            drawFunc: function (canvas) {
                var context = canvas.getContext();
                context.beginPath();
                context.moveTo(-5, -20);
                context.bezierCurveTo(-40, -90, 40, -90, 5, -10);
                context.closePath();
                canvas.fillStroke(this);
            },
            opacity: 0.8,
            fill: '#00dddd',
            strokeWidth: 4,
            draggable: true,
            rotation: 2 * Math.PI * n / numPetals
        });

        petal.on('mouseover', function () {
            this.setFill('blue');
            flowerLayer.draw();
        });

        petal.on('mouseout', function () {
            this.setFill('#00dddd');
            flowerLayer.draw();
        });

        flower.add(petal);
    }());
}

stage.on('mouseup', function () {
    document.body.style.cursor = 'default';
});

lineLayer.add(stem);
flower.add(center);
flowerLayer.add(flower);
stage.add(lineLayer);
stage.add(flowerLayer);

// keep stem in sync with center
flowerLayer.on('draw', function () {
    stem.attrs.points[0] = flower.getPosition();
    lineLayer.draw();
});
*/
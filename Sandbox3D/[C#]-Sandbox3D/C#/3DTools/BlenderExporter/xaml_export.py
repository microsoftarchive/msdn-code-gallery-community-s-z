#!BPY

# """
# Name: 'Xaml (.xaml)...'
# Blender: 239
# Group: 'Export'
# Tooltip: 'Export to Xaml file format'
# """

__author__ = "Daniel Lehenbauer"
__version__ = "1.0 2/25/06"
__url__ = ["3DTools Workspace (Releases), http://workspaces.gotdotnet.com/3DTools",
    "Daniel's Blog (Contact Author), http://blogs.msdn.com/danlehen"]

from StringIO import StringIO
from math import *

import Blender
from Blender import Scene
from Blender import Texture
from Blender import Mathutils
from Blender import Lamp

# Ignore rotations which are less than 1/2 a degree
_rotationLimit = 0.5

def getSafeName(name):
    result = ""

    # CLS identifiers may not begin with a digit
    if name[0].isdigit():
        result = "_"

    # CLS identifiers may contain [_a-zA-Z0-9]
    for i in xrange(len(name)):
        if name[i].isalnum():
            result = result + name[i]
        else:
            result = result + "_"
            
    return result

#
#  Script Configuration
#

def getConfig():
    return Blender.Registry.GetKey("Xaml_Export", True)

def getBatchExportFilename():
    config = getConfig()
    if config:
        return config["Batch_Export"]
    return;

#
#  Debug
#

TraceLevels = {"None": 0, "Error": 1, "Warning": 2, "Trace": 3, "Verbose": 4}
DEBUG=TraceLevels["Warning"]
DEBUG_INDENT=0

def debugPrint(level, message):
    global DEBUG, DEBUG_INDENT
    if level <= DEBUG:
        for i in range(DEBUG_INDENT):
            print "   ",
        print message

def indent():
    global DEBUG_INDENT
    DEBUG_INDENT += 1
    
def unindent():
    global DEBUG_INDENT
    DEBUG_INDENT -= 1

def verbose(message):
    debugPrint(TraceLevels["Trace"], message)

def trace(message):
    debugPrint(TraceLevels["Trace"], message)

def traceMatrix(matrix):
    indent()
    for i in xrange(4):
        str = ""
        for j in xrange(4):
            str += "%f" % matrix[i][j]
            if j < 3: str += ","
        trace(str)
    unindent()

def warn(message):
    debugPrint(TraceLevels["Warning"], message)

def error(message):
    debugPrint(TraceLevels["Error"], message)
        
#
#  Simple XamlWriter
#

class XamlWriter :
    def __init__(self):
        self.indentLevel = 0
        self.tagStack = []
        self.singleLineElement = True
        self.outfile = StringIO()
    
    def writeIndentation(self):
        for i in range(self.indentLevel):
             self.outfile.write("    ")
    
    def beginElement(self, name):
        if len(self.tagStack) > 0 and self.singleLineElement:
            self.outfile.write(">\n")
        self.writeIndentation()
        self.singleLineElement = True
        self.indentLevel += 1
        self.outfile.write("<" + name)
        self.tagStack.append(name)

    def endElement(self):
        name = self.tagStack.pop()
        self.indentLevel -= 1
        if self.singleLineElement:
            self.outfile.write("/>\n")
        else:
            self.writeIndentation()
            self.outfile.write("</" + name + ">\n")
        self.singleLineElement = False
        
    def writeAttribute(self, name, value):
        self.outfile.write(" " + name + '="' + value + '"')

    def writeFragment(self, fragment):
        if fragment == "":
            return
            
        if len(self.tagStack) > 0 and self.singleLineElement:
            self.outfile.write(">\n")
            self.singleLineElement = False

        lines = fragment.split("\n")
        for line in lines:
            self.writeIndentation()
            self.outfile.write(line)
            self.outfile.write("\n")

    def toString(self):
        return self.outfile.getvalue()

#
#  Math Utility
#

def degToRad(angle):
    return angle/180*pi

def radToDeg(angle):
    return angle*180/pi

# Mathutils.Euler seems to expect euler angles in degrees where
# Object.rot is euler angles in radians.
def rotToEuler(rot):
    return Mathutils.Euler(
        radToDeg(rot[0]),
        radToDeg(rot[1]),
        radToDeg(rot[2]))

# Blender objects seem to have a rest orientation facing 0,-1,0.
def rotToDirection(rot):
    euler = rotToEuler(rot)
    matrix = euler.toMatrix()
    restDirection = Mathutils.Vector(0,-1,0)
    return tuple(restDirection * matrix)
    
def rotToQuaternion(rot):
    return rotToEuler(rot).toQuat()

#
#  General Utility
#
    
def rgbToHexString(rgb):
    return "#%.2x%.2x%.2x" % (rgb[0]*255, rgb[1]*255, rgb[2]*255)

def writeXYZ(writer, propertyName, value):
    dimensions = ["X", "Y", "Z"]
    for i in xrange(3):
        writer.writeAttribute(propertyName + dimensions[i], `value[i]`)

def listToString(format, list):
    str = ""
    spc = ""
    
    for i in xrange(len(list)):
        str += spc + format % list[i]
        spc = " "

    return str
    
def matrixToString(matrix):
    str = ""
    
    for i in xrange(4):
        for j in xrange(4):
            str += "%f" % matrix[i][j]
            if j < 3: str += ","
        if i < 3: str += " "

    return str

def quaternionToString(quat):
    # Blender appears to store quaternions as WXYZ
    return "%f,%f,%f,%f" % (quat[1], quat[2], quat[3], quat[0])

#
#  Xaml Exporter
#

class XamlExporter :
    def __init__(self):
        self.writer = XamlWriter()

    #
    #  Transforms
    #

    def writeTranslateTransform(self, writer, loc):
        trace("loc: %f,%f,%f" % tuple(loc))
        if loc[0] == 0 and loc[1] == 0 and loc[2] == 0:
            return False
            
        writer.beginElement("TranslateTransform3D")
        writeXYZ(writer, "Offset", loc)
        writer.endElement()
        return True

    def writeScaleTransform(self, writer, size):
        trace("size: %f,%f,%f" % tuple(size))
        if size[0] == 1 and size[1] == 1 and size[2] == 1:
            return False
            
        writer.beginElement("ScaleTransform3D")
        writeXYZ(writer, "Scale", size)
        writer.endElement()
        return True

    def writeQuaternionRotation(self, writer, quaternion):
        # Blender appears to store quaternions as WXYZ
        if quaternion[0] > _quaternionWLimit:
            writer.beginElement("AxisAngleRotation3D")
            writer.endElement()
            return False
            
        writer.beginElement("AxisAngleRotation3D")

        # Blender appears to store Quaternions in WXYZ order
        len = sqrt(1 - quaternion[0]*quaternion[0])
        x = quaternion[1]/len
        y = quaternion[2]/len
        z = quaternion[3]/len

        angle = radToDeg(2 * acos(quaternion[0]))

        writer.writeAttribute("Axis", "%f,%f,%f" % (x,y,z))
        writer.writeAttribute("Angle", `angle`)
        
        writer.endElement()
        return True
        
    def writeQuaternionRotateTransform(self, writer, quaternion):
        rotationWriter = XamlWriter()

        if not self.writeQuaternionRotation(rotationWriter, quaternion):
            return False

        writer.beginElement("RotateTransform3D")
        writer.beginElement("RotateTransform3D.Rotation")
        writer.writeFragment(rotationWriter.toString())
        writer.endElement()
        writer.endElement()
        return True

    def writeRotateTransform(self, writer, rot):
        trace("rot: %f,%f,%f" % tuple(rot))

        return self.writeQuaternionRotateTransform(writer, rotToQuaternion(rot))
        
    def writeTransformGroup(self, writer, transformWriter, numTransforms):
        assert(numTransforms >= 0)
        assert(numTransforms > 0 or len(transformWriter.toString()) == 0)
        
        if numTransforms == 0:
            return False

        if numTransforms > 1:    
            writer.beginElement("Transform3DGroup")
        writer.writeFragment(transformWriter.toString())
        if numTransforms > 1:    
            writer.endElement()

        return True

    def writeTransforms(self, writer, obj):
        numTransforms = 0
    
        transformWriter = XamlWriter()

        if self.writeRotateTransform(transformWriter, obj.rot):
            numTransforms += 1
        if self.writeScaleTransform(transformWriter, obj.size):
            numTransforms += 1
        if self.writeTranslateTransform(transformWriter, obj.loc):
            numTransforms += 1

        return self.writeTransformGroup(writer, transformWriter, numTransforms)

    #
    #  Materials
    #
    
    def writeSolidColorBrush(self, writer, rgbCol):
        trace("rgbCol: %s" % rgbToHexString(rgbCol))
    
        writer.beginElement("SolidColorBrush")
        writer.writeAttribute("Color", rgbToHexString(rgbCol))
        writer.endElement()                        

    def writeImageBrush(self, writer, texture):
        assert texture.getType() == "Image"

        textureName = texture.getName()
        image = texture.image
        trace("image: %s" % image.getName())
        trace("filename: %s" % image.filename)
        
        writer.beginElement("ImageBrush")
        writer.writeAttribute("x:Name", getSafeName("TE_" + textureName))
        writer.writeAttribute("ImageSource", image.filename)

        # By default WPF brush space is relative to the bounds of the
        # texture coordinates.  Blender texture coordinates are absolute
        # in the [0,0] - [1,1] range.
        writer.writeAttribute("ViewportUnits", "Absolute")
        
        # The default WPF brush space has (0,0) in the upper left corner.
        # Blender's UV space has (0,0) in the bottom left corner.
        writer.writeAttribute("Transform", "1,0,0,-1,0,1")

        # Blender handles texture coordinates outside of the [0,0] - [1,1]
        # range by tiling.  We need to enable this behavior in WPF.
        writer.writeAttribute("TileMode", "Tile")
        
        writer.endElement()

    def writeMaterial(self, writer, material):
        materialName = material.getName()
        trace("Material ('%s'):" % materialName)
        indent()

        writer.beginElement("DiffuseMaterial")
        writer.writeAttribute("x:Name", getSafeName("MA_" + materialName))
        writer.beginElement("DiffuseMaterial.Brush")

        foundTexture = False

        for mTex in material.getTextures():
            if mTex != None:
                texture = mTex.tex
                trace("Texture ('%s'):" % texture.getName())
                indent()
    
                textureType = texture.getType()
 
                if textureType == "Image":
                    self.writeImageBrush(writer, texture)
                    foundTexture = True
                elif textureType != "None":
                    warn("Skipping unsupported Texture type: '%s'" % textureType)

                unindent()

        if foundTexture == False:
            trace("Texture not found for Material '%s', falling back to solid color." % materialName)
            self.writeSolidColorBrush(writer, material.rgbCol)

        writer.endElement()
        writer.endElement()

        unindent()
    
        return True

    def writeDefaultMaterial(self, writer):
        writer.beginElement("DiffuseMaterial")
        writer.beginElement("DiffuseMaterial.Brush")
        self.writeSolidColorBrush(writer, [0.8, 0.8, 0.8])
        writer.endElement()
        writer.endElement()

    def writeMaterials(self, writer, mesh):
        numMaterials = 0
        materialWriter = XamlWriter()

        for material in mesh.materials:
            if self.writeMaterial(materialWriter, material):
                numMaterials += 1

        if numMaterials == 0:
            warn("No material found for mesh '%s'. Using defaut material." % mesh.name)
            self.writeDefaultMaterial(writer)
            return True

        if numMaterials > 1:
            writer.beginElement("MaterialGroup")
        writer.writeFragment(materialWriter.toString())
        if numMaterials > 1:
            writer.endElement()
        return True

    #
    #  Mesh
    #
        
    def writeMesh(self, meshObj):
        objectName = meshObj.getName()
        trace("Object ('%s'):" % objectName)
        indent()

        mesh = meshObj.getData()
        meshName = mesh.name
        trace("Mesh ('%s'):" % meshName)
        indent()

        positions = []
        normals = []
        textureCoordinates = []
        triangleIndices = []

        # WPF does not currently support indexed normals or texture coordinates.
        # To work around this we split the vertices for each face.  In order
        # to correlate the original indices with the WPF indices we maintain a
        # dictionary which maps each Blender index to a list of WPF indices.
        indexMap = {}

        for face in mesh.faces:
            numVerts = len(face.v)

            # We expect mesh faces to be triangles or quads
            assert 3 <= numVerts and numVerts <= 4

            newIndices = []
            uvIndex = 0;
            
            for vertex in face.v:
                index = vertex.index

                position = mesh.verts[index].co
                normal = mesh.verts[index].no
                if mesh.hasFaceUV():
                    textureCoordinate = face.uv[uvIndex]
                    uvIndex += 1
                
                if not indexMap.has_key(index):
                    indexMap[index] = []
                else:
                # If this index is already mapped scan our entries to see if
                    # there is already a position/normal/textureCoordinate set
                    # which matches.
                    for i in indexMap[index]:
                        if positions[i] == position and normals[i] == normal and textureCoordinates[i] == textureCoordinate:
                            newIndices.append(index)
                            continue
                
                # We do not already have a matching position/normal/textureCoordinate
                # for this index so we create one and add it to our indexMap.
                indexMap[index].append(len(positions))
                newIndices.append(len(positions))
                positions.append(tuple(position))
                normals.append(tuple(normal))
    
                if mesh.hasFaceUV():
                    textureCoordinates.append(tuple(textureCoordinate))

            assert len(newIndices) == numVerts
    
            triangleIndices.extend([newIndices[0], newIndices[1], newIndices[2]])
        
            if numVerts == 4:
                triangleIndices.extend([newIndices[0], newIndices[2], newIndices[3]])
    
        assert len(positions) == len(normals)
        assert len(textureCoordinates) == len(positions) or len(textureCoordinates) == 0
   
        self.writer.beginElement("GeometryModel3D")
        self.writer.writeAttribute("x:Name", getSafeName("OB_" + objectName))

        materialWriter = XamlWriter()
        if self.writeMaterials(materialWriter, mesh):
            self.writer.beginElement("GeometryModel3D.Material")
            self.writer.writeFragment(materialWriter.toString())
            self.writer.endElement()
            
        transformWriter = XamlWriter()
        if self.writeTransforms(transformWriter, meshObj):
            self.writer.beginElement("GeometryModel3D.Transform")
            self.writer.writeFragment(transformWriter.toString())
            self.writer.endElement()

        self.writer.beginElement("GeometryModel3D.Geometry")
        self.writer.beginElement("MeshGeometry3D")
        self.writer.writeAttribute("x:Name", getSafeName("ME_" + meshName))
        self.writer.writeAttribute("Positions", listToString("%f,%f,%f", positions))
        self.writer.writeAttribute("Normals", listToString("%f,%f,%f", normals))
        self.writer.writeAttribute("TextureCoordinates", listToString("%f,%f", textureCoordinates))
        self.writer.writeAttribute("TriangleIndices", listToString("%d", triangleIndices))
        
        self.writer.endElement()
        self.writer.endElement()
        self.writer.endElement()

        unindent()    
        unindent()    

    def writeLightCommon(self, lampObj):
        lamp = lampObj.getData()
    
        self.writer.writeAttribute("x:Name", getSafeName("LA_" + lamp.getName()))
        self.writer.writeAttribute("Color", rgbToHexString(lamp.col))

    def writeDirectionalLight(self, lampObj):
        trace("type: Sun (Directional)")
        self.writer.beginElement("DirectionalLight")
        self.writeLightCommon(lampObj)
        self.writer.writeAttribute("Direction", "%f,%f,%f" % rotToDirection(lampObj.rot))
        self.writer.endElement()
    
    def writePointLightCommon(self, lampObj):
        loc = lampObj.loc
        lamp = lampObj.getData()

        self.writer.writeAttribute("Position", "%f,%f,%f" % lampObj.loc)

        mode = lamp.getMode()
        energy = lamp.getEnergy()
        dist = lamp.getDist()

        if mode & Lamp.Modes.Sphere:
            warn("The Sphere feature on lamps is approximated during export.");
            self.writer.writeAttribute("Range", `dist`)
            
        cAttn = 1/energy;
        lAttn = 1/(energy * dist);
        qAttn = 0;

        if mode & Lamp.Modes.Quad:
            warn("The Quad feature on lamps is approximated during export.");
            qAttn = lAttn * lamp.getQuad1();
            lAttn = lAttn * lamp.getQuad2();
    
        if cAttn != 1: self.writer.writeAttribute("ConstantAttenuation", `cAttn`)
        if lAttn != 0: self.writer.writeAttribute("LinearAttenuation", `lAttn`)
        if qAttn != 0: self.writer.writeAttribute("QuadraticAttenuation", `qAttn`)
        
    def writePointLight(self, lampObj):
        trace("type: Lamp (Point)")
        self.writer.beginElement("PointLight")
        self.writeLightCommon(lampObj)
        self.writePointLightCommon(lampObj)
        self.writer.endElement()
    
    def writeSpotLight(self, lampObj):
        trace("type: Spot")
        lamp = lampObj.getData()
    
        self.writer.beginElement("SpotLight")
        self.writeLightCommon(lampObj)
        self.writer.writeAttribute("Direction", "%f,%f,%f" % rotToDirection(lampObj.rot))
        self.writePointLightCommon(lampObj)
        self.writer.writeAttribute("OuterConeAngle", "%f" % lamp.getSpotSize())
        if lamp.getSpotBlend() > 0:
            innerAngle = lamp.getSpotSize() * (1 - lamp.getSpotBlend())
            assert innerAngle < lamp.getSpotSize()

            self.writer.writeAttribute("InnerConeAngle", "%f" % innerAngle)
        self.writer.endElement()
    
    def writeLamp(self, lampObj):
        lamp = lampObj.getData()
        lampName = lamp.getName()
        trace("Lamp ('%s'):" % lampName)
        indent()

        lampType = lamp.getType()
        if lampType == Lamp.Types.Sun:
            self.writeDirectionalLight(lampObj)
        elif lampType == Lamp.Types.Lamp:
            self.writePointLight(lampObj)
        elif lampType == Lamp.Types.Spot:
            self.writeSpotLight(lampObj)
        else:
            unsupportedLamps = { 3 : "Hemi", 4 : "Area", 5 : "Photon" }
            if unsupportedLamps.has_key(lampType):
                warn("Skipping unsupported Lamp type '%s'" % unsupportedLamps[lampType])
            else:
                warn("Skipping unknown Lamp type '%u'" % lampType)

        trace("loc: %f,%f,%f" % (lampObj.loc))
        trace("rot: %f,%f,%f" % (lampObj.rot))
        trace("bias: %f" % lamp.getBias())
        trace("clipEnd: %f" % lamp.getClipEnd())
        trace("clipStart: %f" % lamp.getClipStart())
        trace("col: %s" % rgbToHexString(lamp.getCol()))
        trace("dist: %f" % lamp.getDist())
        trace("energy: %f" % lamp.getEnergy())
        trace("haloInt: %f" % lamp.getHaloInt())
        trace("haloStep: %i" % lamp.getHaloStep())
        trace("mode: %i" % lamp.getMode())
        trace("quad1: %f" % lamp.getQuad1())
        trace("quad2: %f" % lamp.getQuad2())
        trace("samples: %i" % lamp.getSamples())
        trace("softness: %f" % lamp.getSoftness())
        trace("spotBlend: %f" % lamp.getSpotBlend())
        trace("spotSize: %f" % lamp.getSpotSize())

        unindent()

    def writeScene(self, sceneObj, fileout):
        self.writer.beginElement("Model3DGroup")
        self.writer.writeAttribute("xmlns", "http://schemas.microsoft.com/winfx/2006/xaml/presentation")
        self.writer.writeAttribute("xmlns:x", "http://schemas.microsoft.com/winfx/2006/xaml")

        children = sceneObj.getChildren()
        
        for child in children:
            childType = child.getType()
    
            if childType == "Mesh":
                self.writeMesh(child)
            elif childType == "Lamp":
                self.writeLamp(child)
            else:
                warn("Skipping unsupported object type in scene: '" + child.getType() + "'")
                
        self.writer.endElement()
        fileout.write(self.writer.toString())

#
#  Global
#
    
def export(filename):
    trace("Exporting to file: '" + filename)
 
    verbose("Configuration:")
    indent()
    verbose("_rotationLimit='%f'" % _rotationLimit)
    verbose("_quaternionWLimit='%f'" % _quaternionWLimit)
    unindent()
    
    exporter = XamlExporter()
    fileout = open(filename, 'w')
    try:
        exporter.writeScene(Scene.GetCurrent(), fileout)
    finally:
        fileout.close()
    
def onFileSelected(filename):
    if filename.find('.xaml', -5) <= 0:
        filename += '.xaml'

    if Blender.sys.exists(filename):
        if Blender.Draw.PupMenu("File Already Exists, Overwrite?%t|Yes%x1|No%x0") != 1:
            return

    export(filename)

#
#  Main
#
    
_quaternionWLimit = cos(degToRad(_rotationLimit)/2)
    
filename = getBatchExportFilename()
if filename:
    export(filename)
else:
    filename = Blender.sys.makename(ext=".xaml")
    Blender.Window.FileSelector(onFileSelected, "Export Xaml", filename)

trace("Xaml_Export.py Finished.")

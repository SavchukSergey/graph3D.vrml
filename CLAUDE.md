# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is a VRML97 (Virtual Reality Modeling Language) parser implementation in C#. It parses 3D scene descriptions conforming to the VRML97 specification (http://tecfa.unige.ch/guides/vrml/vrml97/spec/).

## Build and Test Commands

### Build the solution
```bash
dotnet build Graph3D.Vrml.sln
```

### Run all tests
```bash
dotnet test Graph3D.Vrml.Test/Graph3D.Vrml.Test.csproj
```

### Run a specific test
```bash
dotnet test Graph3D.Vrml.Test/Graph3D.Vrml.Test.csproj --filter "FullyQualifiedName~VRMLTokenizerTest.TokenizerTest"
```

### Build for release
```bash
dotnet build Graph3D.Vrml.sln -c Release
```

## Architecture

### Parser Pipeline

The parsing process follows a two-stage pipeline:

1. **Tokenization** (`Graph3D.Vrml/Tokenizer/`): Converts VRML text into tokens using a state machine pattern
   - `Vrml97Tokenizer` is the main tokenizer entry point
   - Different states handle numbers, strings, comments, punctuation, etc.
   - Produces `VRML97Token` objects with types defined in `VRML97TokenType`

2. **Parsing** (`Graph3D.Vrml/Parser/`): Converts tokens into a scene graph
   - `VrmlParser` orchestrates the parsing process
   - `ParserContext` maintains parsing state, named node registry, and field/node container stacks
   - `FieldParser` handles field value parsing
   - `NodeFactory` creates node instances from type identifiers

### Node Hierarchy

All VRML nodes inherit from `BaseNode` (`Graph3D.Vrml/Nodes/BaseNode.cs`):
- Manages fields, exposed fields, event inputs/outputs via dictionaries
- Supports node naming, parent tracking, cloning
- Uses visitor pattern for traversal (`INodeVisitor`)

Node categories in `Graph3D.Vrml/Nodes/`:
- **Grouping** (`Grouping/`): Transform, Group, Anchor - nodes that contain children
- **Geometry** (`Geometry/`): Box, Sphere, Cone, Cylinder, IndexedFaceSet, etc.
- **Appearance** (`Appearance/`): Material, Texture nodes, TextureTransform
- **Bindable** (`Bindable/`): Viewpoint, NavigationInfo, Background
- **Light Sources** (`LightSources/`): DirectionalLight, PointLight
- **Sensors** (`Sensors/`): TimeSensor and other interaction nodes
- **Interpolation** (`Interpolation/`): Animation interpolators

### Field System

Fields represent node properties (`Graph3D.Vrml/Fields/`):
- **SF (Single-valued)**: SFBool, SFColor, SFFloat, SFInt32, SFNode, SFRotation, SFString, SFTime, SFVec2f, SFVec3f, SFImage
- **MF (Multi-valued)**: MFColor, MFFloat, MFInt32, MFNode, MFRotation, MFString, MFVec2f, MFVec3f
- All inherit from `Field` base class
- Use visitor pattern (`IFieldVisitor`) for type-safe field operations
- Access types defined in `FieldAccessType`: Field, ExposedField, EventIn, EventOut

### Scene Graph

Entry point is `VrmlScene` which contains a root `SceneGraphNode`. The parser populates this tree structure by:
1. Creating nodes via `NodeFactory`
2. Registering named nodes (DEF) in `ParserContext.namedNodes`
3. Resolving node references (USE) during parsing
4. Supporting PROTO/EXTERNPROTO for custom node types

## Target Frameworks

- Main library: `net9.0`
- Test project: `net9.0`

## Test Structure

Tests are in `Graph3D.Vrml.Test/` and use NUnit. Test VRML files (`.wrl`) are embedded resources:
- `D2.wrl`, `D3.wrl`, `D4.wrl` - Examples from VRML97 specification
- `Ant.WRL` - Large example file for comprehensive testing
- `rose.wrl` - Additional test scene

Tests are organized by functionality matching the source structure (e.g., `Parser/Nodes/Geometry/BoxNodeTest.cs`).

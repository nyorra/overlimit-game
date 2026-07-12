# Low-Poly Car Model Preparation & FBX Export Settings

This document defines the production and export pipeline for game-ready low-poly vehicles with modular components, detached wheels, and anchor points (`Empty` objects).

---

## 1. Asset Architecture & Hierarchy

To ensure a flexible and playable asset, maintain the specific independent object structure inside the Blender Outliner:

- **Separated Mesh Components:** Keep functional parts as distinct mesh objects to allow individual material assignment or vertex-color setups:
  - `Body` (Main car chassis)
  - `Headlights` (Front lights mesh)
  - `Backlights` (Rear lights mesh)
  - `Number` (License plate mesh)
- **Wheel Anchor Points (`Empty` Objects):** Use Plain Axes (`Empty`) for dynamic wheel spawning and physics attachment. Name them strictly by position:
  - `FL` (Front Left)
  - `FR` (Front Right)
  - `RL` (Rear Left)
  - `RR` (Rear Right)

---

## 2. Step-by-Step Production Pipeline

### 2.1. Quad-Based Modeling & Transforms

- **Topology:** Model using strictly 4-sided polygons (Quads).
- **Transforms Leveling:** Ensure the pivot points (Origins) are correctly placed. Apply all transformations for the main body and wheels before setup:
  - `Scale: 1.0, 1.0, 1.0`
  - `Location: 0.0, 0.0, 0.0`
  - `Rotation: 0.0, 0.0, 0.0`

### 2.2. Modifier Stack Management

- Keep your modifier stack (e.g., Mirror, Bevel, Solidify) active during production.
- Do not apply them manually; the export preset handles automated baking.

### 2.3. Geometry & N-Gon Validation

- Run an explicit check for non-four-sided polygons before exporting.
- _How-to:_ In Edit Mode, use `Select -> Select All by Trait -> Faces by Sides` (set Number of Vertices to `Not Equal to 4`) to catch and fix N-gons or stray triangles.

---

## 3. FBX Export Preset Configuration

When exporting, select **FBX** format and match the following parameters exactly:

### 📥 Include

- **Limit to:** Check `[x] Selected Objects`
- **Object Types:** Select **only** `Empty` and `Mesh` (Hold `Shift` to multi-select)

### 📐 Transform

- **Scale:** `1.00`
- **Apply Scalings:** `FBX All`
- **Forward:** `- Z Forward`
- **Up:** `X Up`
- **Apply Unit:** Checked `[x]`
- **Use Space Transform:** Checked `[x]`
- **Apply Transform:** Unchecked `[ ]` _(Crucial: keeping this off preserves correct Empty local orientations)_

### 🔷 Geometry

- **Smoothing:** `Face`
- **Apply Modifiers:** Checked `[x]` _(Automates modifier stack baking)_
- **Triangulate Faces:** Checked `[x]` _(Safely converts validated quads into game-ready triangles)_
- **Vertex Colors:** `sRGB`
- _All other checkboxes in this section must be Unchecked `[ ]`_

### 🦴 Armature

- **Primary Bone Axis:** `Y Axis`
- **Secondary Bone Axis:** `X Axis`
- **Armature FBX...:** `Null`
- **Only Deform Bones:** Unchecked `[ ]`
- **Add Leaf Bones:** Checked `[x]`

---

## 4. Pre-Export Quality Assurance Checklist

- [ ] All mesh components (`Body`, `Headlights`, `Backlights`, `Number`) have their transforms applied.
- [ ] Wheel anchor points (`FL`, `FR`, `RL`, `RR`) are placed at the exact spinning centers of the wheels.
- [ ] Mesh validation tool reports 0 N-gons in the scene.
- [ ] Active modifiers are clean and do not cause shading artifacts.
- [ ] All required objects (Meshes + Empties) are selected in the viewport prior to export.

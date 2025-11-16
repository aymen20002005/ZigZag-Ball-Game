# roll-ball-game

## Level Generator System

```mermaid
flowchart TD

A[Game Start] --> B[OnAwakeEvent]
B --> C[Generate Level]
C --> D[FixedUpdate Loop]

D --> E{Is player near last tiles?}
E -->|Yes| F[TryCreateTileLines]
E -->|No| D

F --> G[Create Tile Line]
G --> H[Spawn Tiles and Optional Coins]
H --> D

D --> I{Tiles far behind player?}
I -->|Yes| J[Return to Object Pool]
I -->|No| D

J --> D

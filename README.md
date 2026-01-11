# Orion Framework

**Orion** is a modular Unity framework for building 3D games with clean architecture, entity management, and event-driven systems.

### Features
- **Entity System**: manage game objects via ScriptableObjects (`EntityDefinition`, `EntityRegistry`, `EntityFactory`).  
- **EventBus**: lightweight event system for decoupled communication between systems.  
- **Game Loop**: centralized update loop with `OnUpdate`, `OnFixedUpdate`, `OnLateUpdate`, and `OnUnscaledTimeUpdate`.  
- **Module System**: plug-and-play modules (`IFunctionalModule`) with `Init()`, `Run()`, `Dispose()` lifecycle, integrated via Zenject.  
- **Editor Tools**: utilities for creating and registering entities, level modules, and custom inspectors.  

### Highlights
- Fully **SO-driven**: configuration and entities via ScriptableObjects.  
- **DI via Zenject**: easy service injection and management.  
- Modular and event-driven architecture for flexible game design.  
- Works across genres: RPG, shooters, adventure, and arcade games.  

### Links
- GitHub: [Orion Framework](https://github.com/Na9asaki/Framework)  
- Itch.io: [profile](https://na9asaki.itch.io/)

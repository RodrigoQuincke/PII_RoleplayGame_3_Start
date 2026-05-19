<img alt="UCU" src="https://www.ucu.edu.uy/plantillas/images/logo_ucu.svg" width="150"/>

# Universidad Católica del Uruguay

## Facultad de Ingeniería y Tecnologías

### Programación II

---

# Encuentros en la Tierra Media — Entrega Final

## Descripción del proyecto

Este trabajo es la continuación del juego de rol que venimos desarrollando durante el curso. La idea central es simular encuentros de combate entre héroes y enemigos, donde cada personaje tiene atributos, items de ataque y defensa, y comportamientos propios.

A lo largo del trabajo fuimos construyendo el sistema y modificandolo con conceptos nuevos que fuimos aprendiendo en el curso: primero modelamos los personajes, después los items, luego los enemigos, y finalmente el sistema de encuentros. Cada entrega se apoyó en la anterior.

---

## Estructura del proyecto

El proyecto está organizado en varias clases que representan los distintos elementos del juego:

### Personajes

- **`Character`** — clase base abstracta de la que heredan todos los personajes. Tiene los atributos comunes: nombre, salud, ataque, defensa, y el equipamiento. También implementa la lógica de `ReceiveAttack`, `Cure`, `GetTotalAttack` y `GetTotalDefense`, calculando el total sumando los valores del personaje más los de sus items.

- **`Heroes`** — extiende `Character` y representa a los personajes buenos. Agrega los puntos de victoria acumulados (`AccumulatedVictoryPoints`) y el método `AddVictoryPoints`.

- **`Enemies`** — también extiende `Character` y representa a los enemigos. A diferencia de los héroes, los enemigos no acumulan VP sino que *tienen* un valor fijo de VP que entregan al héroe que los derrota.

### Héroes implementados

| Clase | Ataque base | Defensa base | Salud | Equipamiento |
|---|---|---|---|---|
| `Knight` | 150 | 100 | 300 | Sword, Shield, Armor |
| `Wizard` | 50 | 80 | 150 | Staff, SpellsBook |
| `Archer` | 90 | 30 | 100 | Bow, Armor |
| `Dwarves` | 70 | 50 | 400 | Axe, Helmet, Shield |
| `Elves` | 50 | 20 | 300 | SpellsBook |
| `Giant` | 100 | 0 | 500 | — |

### Enemigos implementados

| Clase | Ataque | Defensa | Salud | VP |
|---|---|---|---|---|
| `Goblin` | 30 | 10 | 50 | 10 |
| `Zombie` | 20 | 5 | 80 | 15 |
| `Skeleton` | 25 | 15 | 40 | 12 |
| `Devil` | 60 | 40 | 150 | 50 |

### Items

Los items se dividen según su función:

- **Ofensivos** (`IOffensiveItem`): suman ataque. Incluye `Sword`, `Axe`, `Bow`, `Staff`.
- **Defensivos** (`IDefensiveItem`): suman defensa. Incluye `Shield`, `Armor`, `Helmet`.
- **Mixtos**: el `SpellsBook` implementa ambas interfaces. Su ataque y defensa dependen de los hechizos (`Spell`) que tenga cargados. Cada `Spell` tiene un valor de ataque y uno de defensa.

### El encuentro (`Encounter`)

La clase `Encounter` es donde pasa toda la acción. El método `DoEncounter` recibe una lista de enemigos y una lista de héroes y ejecuta la batalla siguiendo esta lógica:

1. Los enemigos atacan primero. Cada enemigo ataca a un héroe según su posición en la lista. Si hay más enemigos que héroes, se va rotando desde el primero.
2. Los héroes sobrevivientes atacan a todos los enemigos, uno por uno.
3. Cuando un héroe mata a un enemigo, se lleva sus VP. Si ese héroe llega a 5 o más VP acumulados, se cura (vuelve a su salud inicial).
4. El encuentro termina cuando todos los héroes o todos los enemigos están muertos.

---

## Decisiones de diseño

Algunas cosas que tuvimos que pensar y decidir durante el desarrollo:

**Herencia vs. interfaces** — Usamos herencia para compartir comportamiento entre personajes (`Character → Heroes`, `Character → Enemies`) e interfaces para los items (`IOffensiveItem`, `IDefensiveItem`). El `SpellsBook` fue el caso más interesante porque necesitaba ser las dos cosas a la vez, y para eso implementa ambas interfaces.

**Cálculo de ataque y defensa** — El `GetTotalAttack()` y `GetTotalDefense()` están en `Character` e iteran sobre el equipamiento buscando items que implementen la interfaz correspondiente. Así no hay que sobreescribir esos métodos en cada subclase.

**El SpellsBook** — Este fue bastante particular. Como los hechizos suman distintos valores, el libro recalcula su ataque y defensa total cuando se le consulta (`GetTotalAttack()` y `GetTotalDefense()` propios), y actualiza sus propiedades `AttackValue` y `DefenseValue`. De esa forma cuando `Character` itera el equipamiento, lee los valores ya actualizados.

---

## Cómo ejecutar el proyecto

El `Program.cs` arma un ejemplo básico con un Gigante y un Mago de fuego contra un Goblin y un Zombie. El mago tiene un hechizo de bola de fuego cargado en su libro.

La salida muestra cada derrota con el nombre del enemigo y el héroe que lo mató.

---

## Integrantes del equipo

- Santiago Abella
- Rodrigo García
- Rodrigo Quincke
- Geronimo Sosa

*Programación II — 2026*
<h3>Here is the final project  from Design and Analysis of Information Systems subject. The repository include a documentation along with program itself of the project including UML class diagrams,  activity diagrams, Sequence diagrams, mock up of UI. This program is dedicated to implementation of the followin user story:</h3>


At this stage we want the application to have several types of instruments, namely Electric and String types. For now we want only have violin and guitar as a string instruments, sampling pad as an electric instrument, and electric guitar as both an electric and a string instrument. Every instrument has to have its name, price, description, optionally photo, quantity, and rating derived from reviews(about reviews later). In addition electric instruments have to have their voltage listed, string instruments have to have number of strings and material listed. Guitar has to have a type of strings ("Nylon", "Steel"). Violin has to have information about whether it has replacement strings or not and info if a shoulder rest is present. Sampling pad has to have info about a number of squares and about an input. Electric guitar has to have some info about an input, about a number of singles, and about a number of humbuckers.
For instrument we want to see a list of all instruments, get all instruments of a specific brand, and get description of a specific instrument with all its fields included.
Every instrument is associated with its brand. For every brand we work with we have a contract. In case we cut out the cooperation with a brand, all the contracts with the brand are removed. Every brand has to have its name, description, year of establishment, and optional logo. Every contract has a starting date, a end date, and a textual content.
There are two types of persons, customer and worker, a person can be simultaneously both a worker and a customer, types can change dynamically. Every person has its name, surname, unique email address, unique phone, address. Private data of a person can be changed.
A customer is able to order instrument(s) and pay for it. Also a customer is capable to leave a review on purchased instruments. Every customer has a balance field, a bonus points field.
Every order has an optional description, a delivery address, and info whether order was paid or not. Order can be added, edited, paid by a customer. We want to be able to get all the orders for a specific customer.
Every Review has its content, optional image, rating. Reviews can be added, removed, edited. We want to allow customer to edit reviews he/she left. We want to know once a review was edited.
A worker has minimal salary field(the same for all), salary field(cannot be less than minimal salary), worker type("delivery", "repairing service", "seller", "customer service", "manager"). Every worker belongs to one team, some of the team members may be managers of the team(only if their worker type is manager). For workers we want to be able to get a list of workers for a specific team.
Every team has name, number of workers. Some teams are responsible for events.
Events may be maintained by several teams, also events may include some instruments from the store. Every event has place, start date, finish date, and price.

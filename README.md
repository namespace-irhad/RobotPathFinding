# Basic RobotPathFinding

### Path planning (with space configuration) algorithms (Trapezoid decomposition, Visibility graph and QuadTree)

- All algorithnms implemented in the project are using naive implementation. Further requirement needed to optimize and correctly finish trapezoid decomposition.
- After finding configuration space and setting starting and ending points inside the space you are able to run DFS, BFS, Djisktra and AStar algorithms to find the path.
- Maximum vertices for each osbstacle is 5 (you can change it)
- I'm using shortest euclidean distance to connect the start, end nodes. For better results you would add these in the graph.
- Project is written in Croatian/Bosnian/Serbian, all variables are set with that in mind.

#### TODO
- [ ] More efficient implementation (faster time complexity with sweep-line and radial sweep)
- [ ] Check if the start/end can be directly linked before the path finding algorithms
- [ ] Adjust how start/end are inserted (during the creation of the graph)

#### Visibility graph
![graf_vidljivosti](https://user-images.githubusercontent.com/60628863/189530788-4c6b9fb1-9f55-43a9-9083-31cc7a195a53.png)
#### Quadtree with all path algorithms
![putevi_algoritmima](https://user-images.githubusercontent.com/60628863/189530793-f0e503b7-2992-4c0d-b27e-2574652bacfe.png)
#### Generating obstacles
![generisanje_poligona](https://user-images.githubusercontent.com/60628863/189530794-40e27950-e83a-4edf-a364-f8dd02d0e83b.png)
#### Trapezoid decomposition graph (needs further work, optimizing algorithm might help)
![graf_trapez_dekom](https://user-images.githubusercontent.com/60628863/189530796-5077155c-b629-4a35-b816-02441db73d50.png)
#### Trapezoid decomposition process 
![trapez_dekom_proces](https://user-images.githubusercontent.com/60628863/189530797-27f0d6b4-0d49-4e1b-8b97-7b4b6e854c60.png)
#### Trapezoid decomposition path with Djikstra
![trapez_dekom_put](https://user-images.githubusercontent.com/60628863/189530798-51cf54af-6c80-4b11-a6cb-26759eb97f8e.png)
#### Quadtree process
![quadtree_process](https://user-images.githubusercontent.com/60628863/189530799-49dff7e9-ee9b-4a6d-a2a0-45b8cd5e2157.png)

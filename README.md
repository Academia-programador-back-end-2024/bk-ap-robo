## Desafio: Atividade Robô Tupiniquim

A Agência Espacial Brasileira (AEB) está realizando uma missão de exploração em uma área retangular, onde robôs devem percorrer o terreno enquanto registram informações. Cada robô é representado por uma posição composta por coordenadas X e Y, juntamente com uma letra representando a direção que ele está enfrentando. As orientações são as seguintes: 

- N: norte
- S: sul
- L: leste
- O: oeste

Para controlar o movimento dos robôs, a AEB envia sequências de comandos simples em forma de strings. As letras possíveis nos comandos são:

- E: girar 90 graus para a esquerda (sem mover)
- D: girar 90 graus para a direita (sem mover)
- M: mover uma posição para frente no grid, mantendo a mesma direção

Ao mover o robô para frente, ele se desloca de uma posição (X, Y) para (X, Y+1). Por exemplo, se um robô está na posição (0,0) com a face para o norte, ao executar um comando 'M', ele se moverá para (0,1).

### Funcionalidades do programa:

1. **Entrada de dados:**
    - O usuário informa as dimensões do plano de coordenadas.
    - O usuário fornece as coordenadas iniciais e as ordens de movimento para um determinado número de robôs.

2. **Execução dos movimentos:**
    - O programa executa as ordens de movimento para cada robô.

3. **Atualização da posição e direção:**
    - A posição e a direção de cada robô são atualizadas de acordo com as ordens de movimento.

4. **Saída de dados:**
    - O programa imprime a posição final de cada robô após a execução das ordens.

### Exemplo:

Suponha que a área retangular tenha dimensões 5x5 e dois robôs devem ser controlados. As coordenadas iniciais e as ordens de movimento são as seguintes:

- Robô 1: Posição inicial (1, 2, N), com comandos "EMEMEMEMM"
- Robô 2: Posição inicial (3, 3, L), com comandos "MMRMMRMRRM"

Após a execução das ordens de movimento, a posição final de cada robô será:

- Robô 1: (1, 3, N)
- Robô 2: (5, 1, L)

```
Informe o tamanho do plano de coordenadas (formato: X Y):
5 5
Informe o número de robôs:
2
Robô 1:
Informe a posição inicial e a direção (formato: X Y D):
1 2 N
Informe as ordens de movimento (formato: E, D ou M):
EMEMEMEMM
Robô 2:
Informe a posição inicial e a direção (formato: X Y D):
3 3 L
Informe as ordens de movimento (formato: E, D ou M):
MMDMMDMDDM
Posição final do robô 1: 1,3,N
Posição final do robô 2: 5,1,L
``` 


# unitynoise

A program a [Perlin-Noise](https://en.wikipedia.org/wiki/Perlin_noise) feldolgozása a Unity játékengineben, C# nyelven.
A legegyszerűbb zaj az alap Perlin noise ![Perlin noise](/kepek/twEtm4boI9.png)
Ezt a "scale" változóval lehet nagyítani és kicsinyíteni, valamint az "offset" változópárral mozgatni ![Perlin noise mozgatása](/kepek/vbJdXGnlkH.png)
A zajt a megfelelő RGB skálákkal lehet színezni ![Perlin noise színezése](/kepek/t4udEbycXG.png)

A második típusú zaj a színes Perlin noise, ami 3 Perlin noise R, G, B színértékekként vétele. Ezeket a zajokat külön lehet mozgatni a megfelelő "offset" változókkal ![színes Perlin noise](/kepek/rziFNMJD5k.png)
Valamint az intenzitásuk is színenként változtatható ![színes Perlin noise](/kepek/k58Wr31A0x.png)

Ezt harmadik típus, a színes zaj kerekítése hasznos lehet például egy játékvilág földrajzi egységeinek meghatározásához. A kerekítési célszínértékeket egy beépített Gradient objektumban tárolom ![kerekített színes Perlin noise](/kepek/DWaPUlbFWg.png) ![kerekített színes Perlin noise](/kepek/pbUbMBdUSX.png)

A negyedik típus pedig egy kerekített Perlin noise-t használ maszkként, és ezalatt a színes noise-t jeleníti meg. ![kerekített színes Perlin noise](/kepek/au92FeCymD.png)

Amit nem sikerült elkészítenem, az a Perlin noise felbontásának növelése a "persistence", "lacunarity" változókkal és az oktávok (azaz a zaj "zajossági felbontása") számának megadásával. Félkész megoldásom (a fehér részek fehérsége is nő az oktávok számával): ![színes Perlin noise](/kepek/46oQ80xtra.png)


Futtatáshoz:
  A Unity Editorban a "Scenes" mappában levő "BuildingScene"-t dupla kattintással nyissa meg.
  A baloldali hierarchiában válassza ki a "Plane"-t.
  Jobboldalt a "Noise (Script)" alatt szerkeszthetőek az értékek.
  A futtatáshoz **NEM** szükséges elindítani a játékot, a "Noise (Script)" automatikusan lefut az editorban amikor adatai megváltoznak. ![színes Perlin noise](/kepek/Unity_tySuhsSDS2.png)

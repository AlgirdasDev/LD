# LD

Programos naudojimo instrukcija: 

Pasileidus programa yra nesunku naudotis, kadangi būnate nukreipti į meniu langa kuriama parašyta kas atsitiks pasirinkus tam tikra variantą.


  V0.1
  
  
  Pirmoji iteracija kuriant studentų valdymo sistemą.
  
  Šios iteracijos metu sukurta:
  
  Vartotojo sąsaja
  
  Studentų bei jų pasiekimų valdymas
  
  Duomenų atvaizdavimas
  
  
  V0.2
  
  
Studentų nuskaitymas ir generavimas iš .txt dokumento.


V0.3


Visoje programoje naudojami try - catch blokai su apdorojimu prieš grįžtant į meniu langą


V0.4


Sukurtas studentų bei jų pasiekimų generavimas atsitiktine tvarka naudojant šabloninius vardus bei pavardes, pvz: Vardas1 Pavardė1, Vardas2 Pavardė2 ir t.t.

Tuo pačiu - sugeneravus studentų dokumentus jis yra išskaidomas į du papildomus dokumentus Vargsiukai.txt ir Saunuoliai.txt, kur vargsiukai.txt dokumente saugomi studentai, kurių bendras vidurkis yra mažesnis negu 5, o kietiakai.txt saugomi studentai, kurių bendras vidurkis didesnis arba lygus 5.

5 skirtingo dydžio failu kūrimas užtrunka atitinkamai pagal failo dydi:

1000 įrašų failas sukuriamas per 7ms

10000 įrašų failas sukuriamas per 29ms

1000 įrašų failas sukuriamas per 243ms

1000 įrašų failas sukuriamas per 2331ms

1000 įrašų failas sukuriamas per 22948ms

surūšiuotų studentų išvedimas į du naujus failus per 32520ms


V0.5


Visi testai buvo atliekami rūšiuojant tą patį dokumentą (100000 studentų).

LinkedList: užtruko 274ms.

List: užtruko 254ms.

Queue: užtruko 270ms.

Išvada: greičiausiai veikia List rūšiavimas.


V1.0


Naudojama 1 strategija: Bendro studentai konteinerio (vector, list ir deque tipų) skaidymas (rūšiavimas) į du naujus to paties tipo konteinerius: "vargšiukų" ir "kietiakų". Tokiu būdu tas pats studentas yra dvejuose konteineriuose: bendrame studentai ir viename iš suskaidytų (vargšiukai arba kietiakai)

Konteineriai surašyti nuo greičiausiai atlikusio užduotį iki lėčiausiai (100000 studentų):

List 170ms

Queue 174ms

LinkedList 197ms

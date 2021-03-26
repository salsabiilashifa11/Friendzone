# Tugas Besar 2 Strategi Algoritma
## A. Penjelasan Singkat Mengenai Algoritma BFS dan DFS

BFS (Breadth First Search) adalah salah satu bentuk algoritma pencarian traversal pada struktur graf atau pohon dengan prioritas melebar (Breadth First). Artinya traversal pencarian akan dilakukan secara per-level pada graf / pohon. Pencarian akan dimulai dari suatu node lalu node-node yang bertetangga dengan node awal tersebut akan dibangkitkan dan dikunjungi seluruhnya sebelum melanjutkan ke node di level berikutnya. Pencaruan akan berhenti ketika node yang dicari sudah ditemukan atau semua node sudah dikunjungi. 

DFS (Depth First Search) adalah salah satu bentuk algoritma pencarian secara traversal yang dilakukan pada struktur graf atau pohon. Algoritma DFS melakukan traversal pada setiap node dalam graf atau pohon secara mendalam, artinya algoritma ini akan terus mengunjungi node turunan dari suatu node hingga node yang dicari ditemukan atau pencarian mencapai dead end, yaitu tidak ada lagi node yang bisa didatangi. Ketika mencapai dead end, algoritma DFS akan melakukan backtracking, yaitu mengunjungi node sebelumnya yang telah dikunjungi untuk mencari node lain yang belum dikunjungi.  

## B. Requirement Program

Program yang dibuat berbentuk Windows Form Application sehingga hanya dapat dijalankan pada OS Windows

## C. Cara Menggunakan Program

1. Buka program, program akan menampilkan antarmuka berisi kolom kotak besar berwarna putih dan beberapa tombol. 
2. Seret dan lepas text file yang ingin digunakan keatas kotak putih besar di antarmuka, isi text file akan ditampilkan pada kotak putih tersebut. Format text file adalah angka untuk baris pertama yang mewakili berapa banyak edge dari graph dan dua huruf atau kata yang dipisahkan spasi di baris-baris selanjutnya yang mewakili edge-edge pada graph. 
3. Tekan tombol “Display The Friendship Graph” untuk menampilkan visualisasi graph dan memilih fitur-fitur selanjutnya.
4. Setelah tombol “Display The Friendship Graph” ditekan, program akan menampilkan antarmuka yaitu gambar graph dari inputan sebelumnya dan beberapa kolom drop down.
5. Pilih fitur, algoritma, dan akun asal yang akan ditampilkan tiap fitur pada drop down box yang tersedia. Untuk fitur “Explore Friend”, akan muncul drop down box lagi untuk memilih akun tujuan yang akan dicari dari akun asal. 
6. Tekan tombol “Proceed” untuk menampilkan hasil output dari fitur yang telah dipilih. Output fitur “Friend Recommendation” akan memiliki antarmuka yaitu output teman yang disarankan beserta list mutual friend dengan tiap teman yang disarankan. 
7. Sedangkan output dari fitur “Explore Friend” akan memiliki antarmuka yaitu graph visualisasi dengan jalur berwarna hijau dari akun asal ke akun target, jalur sesuai algoritma yang dipilih. 
8. Untuk kembali ke halaman awal, tekan tombol “Back to The Landing Page” 
9. Untuk menutup program, tekan tombol “Close the program” yang disediakan di tiap halaman. JANGAN menekan tombol “x” merah di kanan atas halama untuk menutup program, program tidak akan tertutup tapi hanya disembunyikan jika menekan tombol tersebut. 

## D. Identitas Pembuat
Shifa Salsabiila / 13519106
Irvin Andryan Pratomo / 13519162
Muhammad Fikri Naufal / 13519158

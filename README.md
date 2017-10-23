KTO KARATAY ÜN˙I VERS˙ITES˙I
DEPT. OF COMPUTER ENGINEERING
CE 472 Data Communications and Networks
Spring 2014, Laboratory Assignment II
Due: 11/05/2014 Sunday, 23:59
1 General Information
This laboratory assignment is concerned with error correction coding. You will implement
the Hamming (8,4) code and apply it to a binary file.
Your program will consist of three modules.
(i) Encoder: This will read a binary file (could be ASCII or UTF text), encode it
according to Hamming(8,4) and produce a binary output file containing the
encoded data to be transmitted.
(ii) Corrupter: This will simulate the communication channel by randomly corrupting
bits in the encoded data. The bit error rate (BER) will be input to your
program, and the corruptor will flip each bit with this probability.
(iii) Decoder: This module will act as the receiver. It will decode (and correctwithin
its capability) the corrupted file and produce the final message.
2 Methodology
The Hamming (8,4) code produces an 8-bit codeword from a 4-bit data block as
follows.
Data block encoded into
¡¡¡¡¡¡¡¡¡!
Codeword
d1d2d3d4 p1p2d1p3d2d3d4p4
Here, the following parity check equations hold:
p1 Åd1 Åd2 Åd4 Æ 0
p2 Åd1 Åd3 Åd4 Æ 0
p3 Åd2 Åd3 Åd4 Æ 0
p1 Åp2 Åd1 Åp3 Åd2 Åd3 Åd4 Åp4 Æ 0
Alternatively, you can write the generator equation as
2
666666666664
p1
p2
d1
p3
d2
d3
d4
p4
3
777777777775
Æ
2
666666666664
1 1 0 1
1 0 1 1
1 0 0 0
0 1 1 1
0 1 0 0
0 0 1 0
0 0 0 1
1 1 1 0
3
777777777775
2
664
d1
d2
d3
d4
3
775
.
1
Note that each byte you read from the input will include two data blocks. Therefore,
you will produce two bytes (two codewords) for each byte of the input.
3 Deliverables
Your program should display the following statistics:
¡ Number of input bits,
¡ Number of corrupted bits,
¡ Number of corrected bits,
¡ Number of undetected/uncorrected bit errors.
Each student is required to submit:
(i) the source code of his/her program,
(ii) the executable, and
(iii) will demonstrate the program with sample runs. (You may also submit the text
file you used as the input.)
There will be three inputs to the program:
(i) the text file, and
(ii) the bit error rate (BER).
There is no restriction on the programming language.
4 Resources
en.wikipedia.org/wiki/Hamming_code
en.wikipedia.org/wiki/Hamming(7,4)
2

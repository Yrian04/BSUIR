import argparse

parser = argparse.ArgumentParser(description="Encrypting of text file by Vigenère cipher")
parser.add_argument(
    "--input", "-i",
    help="name of file for encrypting",
    type=argparse.FileType('r'),
    default="input",
    required=False
)
parser.add_argument(
    "--key", "-k",
    help="name of key file",
    type=argparse.FileType('r'),
    default="key",
    required=False
)
parser.add_argument(
    "--output", "-o",
    help="name of output file",
    type=argparse.FileType('w'),
    default='-',
    required=False
)


def main():
    args = parser.parse_args()
    enc_text = []
    key = args.key.read()
    for i, x in enumerate(args.input.read()):
        enc_text.append(chr((ord(x) + ord(key[i % len(key)])) % 256))
    args.output.write(''.join(enc_text))


if __name__ == "__main__":
    main()

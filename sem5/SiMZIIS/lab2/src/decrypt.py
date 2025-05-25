import argparse

parser = argparse.ArgumentParser(description="Decrypting of text file by Vigenère cipher")
parser.add_argument(
    "--input", "-i",
    help="name of file for decrypting",
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


def decrypt(text, key):
    dec_text = []
    for i, x in enumerate(text):
        dec_text.append(chr((ord(x) - ord(key[i % len(key)])) % 256))
    return ''.join(dec_text)


def main():
    args = parser.parse_args()
    args.output.write(decrypt(args.input.read(), args.key.read()))


if __name__ == "__main__":
    main()

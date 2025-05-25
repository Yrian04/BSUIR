import argparse

from decrypt import decrypt

parser = argparse.ArgumentParser(description="Hacking of text file by Vigenère cipher")
parser.add_argument(
    "--input", "-i",
    help="name of file for decrypting",
    type=argparse.FileType('r'),
    default="input",
    required=False
)
parser.add_argument(
    "--answer", "-a",
    help="name of decrypted file",
    type=argparse.FileType('r'),
    default="key",
    required=False
)


def get_password_getter():
    password = [0]

    def password_getter():
        password_inc()
        return ''.join(chr(x) for x in password)

    def password_inc(i=0):
        if len(password) == i:
            password.append(0)
            return
        if password[i] == 255:
            password[i] = 0
            password_inc(i+1)
        else:
            password[i] += 1

    return password_getter


def main():
    args = parser.parse_args()
    get_password = get_password_getter()
    dec_text = args.input.read()
    while True:
        print(decrypt(dec_text, key := get_password()))
        if input(f"Password: {key} OK?") == 'y':
            break


if __name__ == "__main__":
    main()

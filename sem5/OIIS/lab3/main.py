from PIL import Image


def brightness_alignment(img1, img2):
    # process the first image
    img1_pixels = list(img1.getdata())
    img1_mean_brightness = sum(pixel[0] + pixel[1] + pixel[2] for pixel in img1_pixels) / (len(img1_pixels) * 3)

    # process the second image
    img2_pixels = list(img2.getdata())
    img2_mean_brightness = sum(pixel[0] + pixel[1] + pixel[2] for pixel in img2_pixels) / (len(img2_pixels) * 3)

    # brightness different
    brightness_diff = abs(img1_mean_brightness - img2_mean_brightness) / 2

    # change image brightness
    if img1_mean_brightness > img2_mean_brightness:
        new_img1_pixels = [(max(0, int(pixel[0] - brightness_diff)),
                            max(0, int(pixel[1] - brightness_diff)),
                            max(0, int(pixel[2] - brightness_diff))) for pixel in img1_pixels]

        new_img2_pixels = [(min(255, int(pixel[0] + brightness_diff)),
                            min(255, int(pixel[1] + brightness_diff)),
                            min(255, int(pixel[2] + brightness_diff))) for pixel in img2_pixels]
    else:
        new_img1_pixels = [(min(255, int(pixel[0] + brightness_diff)),
                            min(255, int(pixel[1] + brightness_diff)),
                            min(255, int(pixel[2] + brightness_diff))) for pixel in img1_pixels]

        new_img2_pixels = [(max(0, int(pixel[0] - brightness_diff)),
                            max(0, int(pixel[1] - brightness_diff)),
                            max(0, int(pixel[2] - brightness_diff))) for pixel in img2_pixels]

    new_img1 = Image.new('RGB', img1.size)
    new_img2 = Image.new('RGB', img2.size)

    new_img1.putdata(new_img1_pixels)
    new_img2.putdata(new_img2_pixels)

    return new_img1, new_img2


if __name__ == '__main__':
    # open images
    img1 = Image.open('1.jpg')
    img2 = Image.open('2.jpg')

    new_img1, new_img2 = brightness_alignment(img1, img2)

    new_img1.save('result_1.jpg')
    new_img2.save('result_2.jpg')

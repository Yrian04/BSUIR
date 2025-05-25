import os
import json
from typing import Dict

from pydantic_settings import BaseSettings


class Config(BaseSettings):
    DATABASE_URL: str
    RESOURCE_PATH: str
    POS_TAG_MAP_FILENAME: str

    class Config:
        env_file = '.env'

    def get_pos_tag_map(self) -> Dict[str, str]:
        pos_tag_map_filepath = os.path.join(self.RESOURCE_PATH, self.POS_TAG_MAP_FILENAME)
        with open(pos_tag_map_filepath) as f:
            pos_tag_map = json.load(f)
        return pos_tag_map


settings = Config()
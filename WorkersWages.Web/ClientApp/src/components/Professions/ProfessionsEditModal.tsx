import { AisModal } from "@ais-gorod/react-ui";
import { useCallback, useEffect, useState } from "react";
import { useHistory, useParams } from "react-router-dom";
import { ProfessionEditRequest, WorkersWagesApiClient } from "../../services/WorkersWagesApiClient";
import { ProfessionsEditForm } from './ProfessionsEditForm';

interface Props {
    onDataChanged: () => void;
}

const apiClient = new WorkersWagesApiClient('/extapi');

export const ProfessionsEditModal = (props: Props) => {
    const history = useHistory();
    const { id } = useParams() as {
        id: string;
    };

    const [professionInfo, setProfessionInfo] = useState<ProfessionEditRequest>();
    useEffect(() => {
        /* TODO: Добавить в АПИ подробности на все сущности для вытаскивания данных при редактировании */
    }, [id])

    const propsOnDataChanged = props.onDataChanged;
    const handleSubmit = useCallback(async (data: ProfessionEditRequest) => {
        if (!id) return;

        await apiClient.professionsPUT(+id, data).then((_) => {
            history.goBack();
            propsOnDataChanged();
        });
    }, [id, history, propsOnDataChanged]);

    return (
        <AisModal show={true} onHide={() => history.goBack()} title="Редактирование профессии">
            <ProfessionsEditForm onSubmit={handleSubmit} data={professionInfo} />
        </AisModal>
    );
};

ProfessionsEditModal.displayName = 'ProfessionsEditModal';
